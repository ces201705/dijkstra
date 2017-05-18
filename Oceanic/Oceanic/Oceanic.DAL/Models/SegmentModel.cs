using System;

namespace Oceanic.DAL.Models
{
    public class SegmentModel
    {
        public int Id { get; set; }

        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public LocationModel StartLocation { get; set; }
        public LocationModel EndLocation { get; set; }

        public Decimal Time { get; set; }
        public Decimal Price { get; set; }
    }
}