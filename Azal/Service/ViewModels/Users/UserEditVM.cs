﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Users
{
    public class UserEditVM
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string FatherName { get; set; }
       
        public string? Address { get; set; }
        public string Email { get; set; }
    }
}
