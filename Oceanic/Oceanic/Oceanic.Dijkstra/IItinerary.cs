using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    /// <summary>
    /// Itinerary implementation
    /// </summary>
    public interface IItinerary
    {
        /// <summary>
        /// List of segments.
        /// </summary>
        List<ISegment> Segments
        {
            get;
        }
    }
}