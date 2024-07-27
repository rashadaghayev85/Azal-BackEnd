using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Planes
{
    public class PlaneDetailVM
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
