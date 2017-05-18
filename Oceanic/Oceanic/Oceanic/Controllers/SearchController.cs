using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oceanic.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult SearchResult()
        {
            return View();
        }
        
    }
}