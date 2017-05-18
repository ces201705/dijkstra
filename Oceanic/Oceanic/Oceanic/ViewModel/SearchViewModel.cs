using Oceanic.DAL;
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
        public int Height { get; set; }

        [Required]
        [Display(Name = "Width")]
        public int Width { get; set; }

        [Required]
        [Display(Name = "Depth")]
        public int Depth { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Required]
        public string ItineraryType { get; set; }

        public List<Location> Locations { get; set; }
    }
}