using System;
using System.Collections.Generic;
using System.Text;

namespace NimeniAltii.Models.Photo
{
    public class Photo : PhotoCreate
    {
        public int PhotoId { get; set; }

        public int ApplicationUserId { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}
