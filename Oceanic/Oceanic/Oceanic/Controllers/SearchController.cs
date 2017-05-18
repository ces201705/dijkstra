using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oceanic.Services;
using Oceanic.DAL;

namespace Oceanic.Controllers
{
    public class SearchController : Controller
    {
        private IItineraryService _itineraryService;

        public SearchController(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }

        // GET: Search
        [Authorize]
        public ActionResult Index(SearchViewModel searchViewModel = null)
        {
            Oceanic.DAL.Entities entities = new DAL.Entities();
            if (searchViewModel == null)
            {
                searchViewModel = new SearchViewModel();
            }
            searchViewModel.ItineraryType = ItineraryType.Fastest;
            searchViewModel.Locations = entities.Location.ToList();

            return View(searchViewModel);
        }

        [Authorize]
        public ActionResult SearchResult(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }
            var result = _itineraryService.FindItinerary(model);


            SearchResultViewModel searchResultViewModel = new SearchResultViewModel();
            searchResultViewModel.Segments.Add(new ResultSegment() { DepartureLocationName = "Katowice", DestinationLocationName  = "Warszawa", Provider = "Telstar"});
            searchResultViewModel.Segments.Add(new ResultSegment() { DepartureLocationName = "Warszawa", DestinationLocationName = "Zakopane", Provider = "Oceanic" });
            searchResultViewModel.Segments.Add(new ResultSegment() { DepartureLocationName = "Zakopane", DestinationLocationName = "Krakow", Provider = "Oceanic" });
            searchResultViewModel.Segments.Add(new ResultSegment() { DepartureLocationName = "Krakow", DestinationLocationName = "Serock", Provider = "EastIndia" });
            searchResultViewModel.TotalPrice = 30;
            searchResultViewModel.TotalTime = 10;
            return View(result);
        }

    }
}