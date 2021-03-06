﻿using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaTest.Core.Models
{
    public class AuthUser : EntityObject
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

       // [Required]
        public string UserRole { get; set; }
    }
}
