﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace NewsAPI.Model
{
    public class AnnouncementCreation
    { 

        [Required] 
        public string Title { get; set; }
        public string Message { get; set; }
        public string CategoryId { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
