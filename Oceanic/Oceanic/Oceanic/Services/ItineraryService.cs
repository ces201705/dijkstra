using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oceanic.ViewModel;

namespace Oceanic.Services
{
    public interface IItineraryService
    {
        List<SegmentModel> FindItinerary();
    }

    public class ItineraryService : IItineraryService
    {
        public List<SegmentModel> FindItinerary()
        {
            return new List<SegmentModel>();
        }
    }
}