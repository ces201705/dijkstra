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
        [Display(Name = "Height [m]")]
        public int Height { get; set; }

        [Required]
        [Display(Name = "Width [m]")]
        public int Width { get; set; }

        [Required]
        [Display(Name = "Depth [m]")]
        public int Depth { get; set; }

        [Required]
        [Display(Name = "Weight [kg]")]
        public int Weight { get; set; }

        [Required]
        public ItineraryType ItineraryType { get; set; }

        public List<Location> Locations { get; set; }

        public int StartLocationId { get; set; }

        public int EndLocationId { get; set; }
    }
}