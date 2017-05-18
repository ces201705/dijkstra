using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oceanic.Controllers
{
    public class ItineraryController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetItinerary()
        {
            List<SegmentModel> segments = new List<SegmentModel>();

            segments.Add(new SegmentModel() { SourceLocationName = "Warszawa", EndLocationName = "Serock", Time = 10, Price = 35 });
            segments.Add(new SegmentModel() { SourceLocationName = "Zakopane", EndLocationName = "Katowice", Time = 2, Price = 14 });
            segments.Add(new SegmentModel() { SourceLocationName = "Poznań", EndLocationName = "Szczecin", Time = 32, Price = 24 });
            segments.Add(new SegmentModel() { SourceLocationName = "Warszawa", EndLocationName = "Pisz", Time = 24, Price = 44 });
            return Json(segments, JsonRequestBehavior.AllowGet);
        }
    }
}