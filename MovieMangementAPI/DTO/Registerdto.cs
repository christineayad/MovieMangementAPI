﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMangementAPI.DTO
{
    public class Registerdto
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "E-mail  is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
}
