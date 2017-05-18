using Oceanic.DAL;
using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oceanic.ViewModel;

namespace Oceanic.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ISegmentRepository _segmentRepository;

        public ServiceController()
        {

        }
        public ServiceController(ISegmentRepository segmentRepository1)
        {
            _segmentRepository = segmentRepository1;
        }

        public ActionResult Segments(int parcelWeight, int parcelMaxDimensionSize)
        {
            var segments = new SegmentRepository(new Entities()).GetSegmentsForSearch(parcelWeight, parcelMaxDimensionSize).Select(o => new { SourceLocationName = o.StartLocation.Name, EndLocationName = o.EndLocation.Name, Time = o.Time, Price = o.Price, ProviderName="Oceanic" });

            return Json(segments, JsonRequestBehavior.AllowGet);
        }

    }
}