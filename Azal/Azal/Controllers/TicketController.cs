using AutoMapper;
using Domain.Models;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels;
using Service.ViewModels.Flights;
using Service.ViewModels.Tickets;
using Stripe.Checkout;
using Stripe.Climate;

namespace Azal.Controllers
{
    public class TicketController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly ITicketService _ticketService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TicketController(
                              IFlightService flightService,
                              IAirportService airportService,
                              AppDbContext context,
                              IMapper mapper,
                              ITicketService ticketService
                              )
        {
          
            _flightService = flightService;
            _airportService = airportService;
            _context = context;
            _mapper = mapper;
            _ticketService = ticketService;

        }



        //[HttpPost]
        //public async Task<IActionResult> Search([FromBody] SearchFlightVM data)
        //{
        //    if (data == null)
        //    {
        //        return BadRequest("Invalid search data.");
        //    }

        //    var flights = await _context.Flights
        //        .Where(m => m.DepartureAirport.AirportTranslates
        //                        .Any(dt => dt.Location == data.DepartureAirport) &&
        //                    m.ArrivalAirport.AirportTranslates
        //                        .Any(at => at.Location == data.ArrivalAirport))
        //        .Include(m => m.ArrivalAirport)
        //        .ThenInclude(m => m.AirportTranslates)
        //        .Include(m => m.DepartureAirport)
        //        .ThenInclude(m => m.AirportTranslates)
        //        .ToListAsync();

        //    if (!flights.Any())
        //    {
        //        return Ok(new List<int>());
        //    }

        //    var flightIds = flights.Select(m => m.Id).ToList();
        //    return Ok(flightIds);
        //}

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchFlightVM data)
        {
          
            if (data == null)
            {
                return BadRequest("Invalid search data.");
            }

            // Tüm uçuşları yükleyin
            var flights = await _context.Flights
                .Include(f => f.DepartureAirport)
                    .ThenInclude(a => a.AirportTranslates)
                .Include(f => f.ArrivalAirport)
                    .ThenInclude(a => a.AirportTranslates)
                .ToListAsync();

            // Bellek üzerinde filtreleme yapın
            var filteredFlights = flights
       .Where(f =>
           f.DepartureAirport.AirportTranslates
               .Any(at => at.Location.Equals(data.DepartureAirport, StringComparison.OrdinalIgnoreCase)) &&
           f.ArrivalAirport.AirportTranslates
               .Any(at => at.Location.Equals(data.ArrivalAirport, StringComparison.OrdinalIgnoreCase)) &&
           f.DepartureTime.Year == data.DepatureDate.Year &&
            f.DepartureTime.Month == data.DepatureDate.Month &&
            f.DepartureTime.Day == data.DepatureDate.Day)
       .ToList();


            if (!filteredFlights.Any())
            {
                var result = new SearchResultVM
                {
                    Count = 0,
                    FlightIds = new List<int>()
                };
                return Ok(result);
              //  return Ok(); // Boş sonuç döner
            }

            var flightIds = filteredFlights.Select(f => f.Id).ToList();
            if (flightIds is not null)
            {

            var count = data.Count;
            var result = new SearchResultVM
            {
                Count = count,
                FlightIds = flightIds
            };
                return Ok(result);
            }
            else
            {
                var result = new SearchResultVM
                {
                    Count = 0,
                    FlightIds = flightIds
                };
            return Ok(result); // Uçuş ID'lerini döner
            }

            // return RedirectToAction("Purchase", new { id = flightIds.FirstOrDefault(), count = count });
        }







        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string ids, [FromQuery] int count)
        {
            ViewBag.Count = count;
            var idList = ids?.Split(',').Select(int.Parse).ToList() ?? new List<int>();
            var flights = await _context.Flights
             .Include(m => m.ArrivalAirport)
             .Include(m => m.DepartureAirport)
             .Include(m => m.Plane)
            .Where(f => idList.Contains(f.Id))
             .ToListAsync();

            // Use the idList as needed
            // Example: Fetching related data based on idList

            return View(flights);
        }
       


        [HttpGet]
        public async Task<IActionResult> NotFound()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int id,int count)
        {
            ViewBag.Count = count;
          

            ViewBag.flightId = id;
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Purchase(TicketCreateVM request)
        //{
        //    // ViewBag.Count ilə formdan gələn məlumatı yenidən doldura bilərsiniz
        //    int count = ViewBag.Count;

        //    if (request.Flight == 0)
        //    {
        //        ModelState.AddModelError("Flight", "Input can't be empty");
        //        return View(request);
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(request);
        //    }

        //    // CheckOut metoduna yönləndirərkən count dəyərini də ötürün
        //    return RedirectToAction("CheckOut", new
        //    {
        //        count = count,
        //        Flight = request.Flight,
        //        DocumentExpiryDate = request.DocumentExpiryDate,
        //        DocumentNumber = request.DocumentNumber,
        //        DocumentType = request.DocumentType,
        //        Name = request.Name,
        //        Surname = request.Surname,
        //        FatherName = request.FatherName,
        //        Gender = request.Gender,
        //        DateOfBirth = request.DateOfBirth,
        //        PhoneNumber = request.PhoneNumber,
        //        Email = request.Email
        //    });
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(TicketCreateVM request)
        {

          
                
            if (request.Flight == 0)
                {
                    ModelState.AddModelError("Flight", "Input can't be empty");
                    return View(request);
                }

                if (!ModelState.IsValid)
                {
                    return View(request);
                }
         

          
            return RedirectToAction("CheckOut", request);
             //request`-də bilet məlumatları formdan alınıb

          //   Ödəniş üçün CheckOut metoduna yönləndiririk






        }

        public async Task<IActionResult> CheckOut(TicketCreateVM request)
        {
            
                var flight = await _flightService.GetByIdAsync(request.Flight);
                var datas = await _flightService.GetAllAsync();
                var domain = "https://localhost:7201/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"payment/OrderConfirmation?flightId={request.Flight}&documentExpiryDate={request.DocumentExpiryDate}&documentNumber={request.DocumentNumber}&documentType={request.DocumentType}&name={request.Name}&surname={request.Surname}&fatherName={request.FatherName}& gender ={request.Gender}&dateOfBirth ={request.DateOfBirth}& documentExpiryDate ={request.DocumentExpiryDate}&phoneNumber ={request.PhoneNumber}&email={request.Email}",
                    CancelUrl = domain + "payment/login",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                foreach (var itm in datas)
                {
                    var sessionListItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = flight.Price_azn * 10,
                            Currency = "azn",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = itm.FlightNumber.ToString(),
                            },
                        },
                        Quantity = 2
                    };
                    options.LineItems.Add(sessionListItem);
                }

                var service = new SessionService();
                Session session = service.Create(options);

                // Ödəniş səhifəsinə yönləndirmək
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            
        }
    }
}
