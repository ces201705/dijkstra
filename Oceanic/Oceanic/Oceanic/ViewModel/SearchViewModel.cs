using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oceanic.Models
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [Required]
        [Display(Name = "Width")]
        public string Width { get; set; }

        [Required]
        [Display(Name = "Depth")]
        public string Depth { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Required]
        public string ItineraryType { get; set; }

    }
}