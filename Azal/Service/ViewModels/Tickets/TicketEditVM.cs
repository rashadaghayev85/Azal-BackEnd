using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Tickets
{
    public class TicketEditVM
    {
        public int Id { get; set; }
        public int Price_az { get; set; }
        public int Price_usd { get; set; }
        public int FlightId { get; set; }
    }
}
