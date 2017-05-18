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
        public ActionResult Index()
        {
            Oceanic.DAL.Entities entities = new DAL.Entities();

            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.Locations = entities.Location.ToList();
            searchViewModel.ItineraryType = ItineraryType.Cheapest;

            return View(searchViewModel);
        }

        [Authorize]
        public ActionResult SearchResult(SearchViewModel model)
        {
            var result = _itineraryService.FindItinerary(model);


            var x = ExternalServiceHelper.GetTelstarSegments();
            var y = ExternalServiceHelper.GetEastIndiaSegments();



            SearchResultViewModel searchResultViewModel = new SearchResultViewModel();
            searchResultViewModel.Segments.Add(new ResultSegment() { LocationName = "Katowice" });
            searchResultViewModel.Segments.Add(new ResultSegment() { LocationName = "Warszawa" });
            searchResultViewModel.Segments.Add(new ResultSegment() { LocationName = "Zakopane" });
            searchResultViewModel.TotalPrice = 30;
            searchResultViewModel.TotalTime = 10;
            return View(searchResultViewModel);
        }

    }
}