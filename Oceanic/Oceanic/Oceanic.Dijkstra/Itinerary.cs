using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public class Itinerary : IItinerary
    {
        public Itinerary()
        {
            Segments = new List<ISegment>();
        }

        public List<ISegment> Segments
        {
            get;
            set;
        }
    }
}