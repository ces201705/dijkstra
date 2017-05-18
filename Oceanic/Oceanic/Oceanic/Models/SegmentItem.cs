using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oceanic.Models
{
    public class SegmentItem
    {
        public string SourceLocationName { get; set; }
        public string EndLocationName { get; set; }
        public Decimal Time { get; set; }
        public Decimal Price { get; set; }
    }
}