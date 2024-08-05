using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
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
        public PaymentController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        public async Task<IActionResult> Index()
        {
            var data=await _flightService.GetAllAsync();    
            return View(data);
        }
        public async Task<IActionResult> OrderConfirmation()
        {
            return View();  
        }
        public async Task<IActionResult> CheckOut()
        {
            var datas = await _flightService.GetAllAsync();
            var domain = "https://localhost:7201/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"payment/OrderConfirmation",
                CancelUrl=domain + "payment/login",
                LineItems=new List<SessionLineItemOptions>(),  
                Mode="payment",
                //CustomerEmail="rashadra@code.edu.az"
            };

            foreach (var item in datas)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = item.Price_azn,//(long)(item.Price_azn*item.PassengerCount),
                        Currency="azn",
                        ProductData=new SessionLineItemPriceDataProductDataOptions
                        {
                            Name=item.FlightNumber.ToString(),
                        },
                    },
                        Quantity=2//item.PassengerCount
                };
                options.LineItems.Add(sessionListItem);
            }
            var service = new SessionService();
            Session session = service.Create(options);
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
