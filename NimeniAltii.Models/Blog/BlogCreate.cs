using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NimeniAltii.Models.Blog
{
    public class BlogCreate
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Campul *Titlu este gol.")]
        [MinLength(10, ErrorMessage = "Campul *Titlu este prea scurt (minim 10 de caractere).")]
        [MaxLength(50, ErrorMessage = "Campul *Titlu este prea lung (maxim 50 de caractere).")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campul *Continut este gol.")]
        [MinLength(300, ErrorMessage = "Campul *Continut este prea scurt (minim 300 de caractere).")]
        [MaxLength(3000, ErrorMessage = "Campul *Continut este prea lung (maxim 3000 de caractere).")]
        public string Content { get; set; }

        public int? PhotoId { get; set; }


    }
}
