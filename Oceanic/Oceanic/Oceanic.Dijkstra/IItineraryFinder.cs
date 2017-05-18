using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    /// <summary>
    /// Class to lookup for Itinerary.
    /// </summary>
    public interface IItineraryFinder
    {
        /// <summary>
        /// Implementation of GraphLogic.
        /// </summary>
        IGraphLogic GraphLogic
        {
            get;
        }

        /// <summary>
        /// Get Itinerary from two different vertexes of Graph.
        /// </summary>
        /// <param name="vertexA">First Itinerary vertex</param>
        /// <param name="vertexB">Last Itinerary vertex </param>
        /// <param name="weightFunction">Weight of segment function</param>
        /// <returns></returns>
        IItinerary GetItinerary(IVertex vertexA, IVertex vertexB, Func<ISegment, decimal> weightFunction);
    }
}