﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Contact :BaseEntity
	{
	
		public string Email { get; set; }
		public string Message { get; set; }
		public string? Subject { get; set; }
	}
}
