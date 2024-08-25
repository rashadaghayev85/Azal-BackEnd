using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Tickets;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Session = Stripe.Checkout.Session;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;
using SessionService = Stripe.Checkout.SessionService;

namespace Azal.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly ITicketService _ticketService;
        private readonly EmailService _emailService;
        public PaymentController(IFlightService flightService, ITicketService ticketService, EmailService emailService)
        {
            _flightService = flightService;
            _ticketService = ticketService;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            var data=await _flightService.GetAllAsync();    
            return View(data);
        }
        //public async Task<IActionResult> OrderConfirmation()
        //{
        //    return View();  
        //}
        public async Task<IActionResult> PaymentFailed()
        {
            ModelState.AddModelError("", "Ödəniş uğursuz oldu. Yenidən cəhd edin.");
            return View("Purchase");
        }
        public async Task<IActionResult> OrderConfirmation(int flightId,string documentExpiryDate,string gender,string documentNumber,string documentType,string email,string name,string surname,string fatherName,string phoneNumber,DateTime dateOfBirth,int count)
        {
            // request-i burada bərpa edə bilərsiniz, məsələn sessiondan və ya database-dən
            var ticket = new TicketCreateVM
            {
                Flight = flightId,
                DocumentExpiryDate=documentExpiryDate,
                Gender=gender,
                DocumentNumber=documentNumber,
                DocumentType=documentType,
                Email=email,
                Name=name,
                Surname=surname,
                FatherName=fatherName,
                PhoneNumber=phoneNumber,
                DateOfBirth=dateOfBirth
                
                // Digər məlumatları buraya əlavə edə bilərsiniz
            };

            await _ticketService.CreateAsync(ticket,count);

            await _emailService.SendTicketAsync(email, "Biletin Təsdiqi", $"Bilet uğurla alınmışdır");
            // Sifariş təsdiq səhifəsinə yönləndirmək və ya istifadəçiyə mesaj göstərmək
            //return View("OrderConfirmation", ticket);
            return Redirect("/ticket/OrderConfirmation");
            
        }
        //public async Task<IActionResult> CheckOut(TicketCreateVM request)
        //{
        //    var datas = await _flightService.GetAllAsync();
        //    var domain = "https://localhost:7201/";
        //    var options = new SessionCreateOptions
        //    {
        //        SuccessUrl = domain + $"payment/OrderConfirmation",
        //        CancelUrl = domain + "payment/login",
        //        LineItems = new List<SessionLineItemOptions>(),
        //        Mode = "payment",
        //        //CustomerEmail="rashadra@code.edu.az"
        //    };

        //    foreach (var item in datas)
        //    {
        //        var sessionListItem = new SessionLineItemOptions
        //        {
        //            PriceData = new SessionLineItemPriceDataOptions
        //            {
        //                UnitAmount = item.Price_azn,//(long)(item.Price_azn*item.PassengerCount),
        //                Currency = "azn",
        //                ProductData = new SessionLineItemPriceDataProductDataOptions
        //                {
        //                    Name = item.FlightNumber.ToString(),
        //                },
        //            },
        //            Quantity = 2//item.PassengerCount
        //        };
        //        options.LineItems.Add(sessionListItem);
        //    }
        //    var service = new SessionService();
        //    Session session = service.Create(options);
        //    Response.Headers.Add("Location", session.Url);
        //    await _ticketService.CreateAsync(request);
        //    return new StatusCodeResult(303);
        //}


    }
}
