﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
  public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
