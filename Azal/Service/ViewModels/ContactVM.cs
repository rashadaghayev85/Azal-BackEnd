using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
	public class ContactVM
	{
	
		public string Email { get; set; }
		public string Message { get; set; }
		[Required]
		public string Subject { get; set; }
	}
}
