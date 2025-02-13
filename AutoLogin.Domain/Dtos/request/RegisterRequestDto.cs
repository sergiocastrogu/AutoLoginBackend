﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Domain.Dtos.request
{
    public class RegisterRequestDto
    {
        public string Identification {  get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
