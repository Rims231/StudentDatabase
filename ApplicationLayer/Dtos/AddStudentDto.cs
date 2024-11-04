﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dtos
{
    public class AddStudentDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}
