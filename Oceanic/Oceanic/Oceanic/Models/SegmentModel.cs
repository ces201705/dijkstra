using System;

namespace Oceanic.Models
{
    public class SegmentModel
    {
        public string SourceLocationName { get; set; }
        public string EndLocationName { get; set; }
        public Decimal Time { get; set; }
        public Decimal Price { get; set; }
    }
}