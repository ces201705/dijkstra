using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oceanic.Services;

namespace Oceanic.Controllers
{
    public class SearchController : Controller
    {
        private IItineraryService _itineraryService;

        public SearchController()
        {
            
        }

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
            searchViewModel.Weight = 0;
            searchViewModel.Depth = 0;
            searchViewModel.Height = 0;
            searchViewModel.Width = 0;

            return View(searchViewModel);
        }

        [Authorize]
        public ActionResult SearchResult(SearchViewModel model)
        {
            //var result = _itineraryService.FindItinerary(model);

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