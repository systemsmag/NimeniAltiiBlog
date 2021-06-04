using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NimeniAltii.Models.Account
{
   public class ApplicationUserLogin
    {
        [Required(ErrorMessage = "Campul *Utilizator este gol.")]
        [MinLength(5, ErrorMessage = "Numele de *Utilizator este prea mic (5-20).")]
        [MaxLength(20, ErrorMessage = "Numele de *Utilizator este prea mare (5-20).")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Campul *Parola este gol.")]
        [MinLength(10, ErrorMessage = "Parola setata este prea mica (10-50).")]
        [MaxLength(50, ErrorMessage = "Parola setata este prea mare (10-50).")]
        public string Password { get; set; }
    }
}
