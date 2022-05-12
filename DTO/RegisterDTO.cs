﻿using System.ComponentModel.DataAnnotations;

namespace ApiProjectTest.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
    }
}
