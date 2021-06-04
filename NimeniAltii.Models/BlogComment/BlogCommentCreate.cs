using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NimeniAltii.Models.BlogComment
{
    public class BlogCommentCreate
    {
        public int BlogCommentId { get; set; }

        public int? ParentBlogCommentId { get; set; }

        public int BlogId { get; set; }
        [Required(ErrorMessage = "Campul *Continut este gol.")]
        [MinLength(10, ErrorMessage = "Campul *Continut este prea scurt (minim 10 caractere).")]
        [MaxLength(300, ErrorMessage = "Campul *Continut este prea lung (maxim 300 de caractere).")]
        public string Content { get; set; }

    }
}
