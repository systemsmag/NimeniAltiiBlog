using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NimeniAltii.Models.Account
{
   public class ApplicationUserCreate : ApplicationUserLogin
    {
        
        [MinLength(10, ErrorMessage = "Numele de complet este prea mic (minim 10 caractere).")]
        [MaxLength(30, ErrorMessage = "Numele de complet este prea mare (maxim 30 de caractere).")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Campul *Email este gol.")]
        [MaxLength(30, ErrorMessage = "Contul de *Email este prea mare (maxim 30 de caractere).")]
        [EmailAddress(ErrorMessage = "Formatul pentru *Email este gresit.")]

        public string Email { get; set; }
    }
}
