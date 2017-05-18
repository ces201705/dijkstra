using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public class ItineraryFinder : IItineraryFinder
    {
        public IGraphLogic GraphLogic
        {
            get;
            set;
        }

        public ItineraryFinder(IGraphLogic graphLogic)
        {
            GraphLogic = graphLogic;
        }

        public IItinerary GetItinerary(IVertex vertexA, IVertex vertexB, Func<ISegment, decimal> weightFunction)
        {
            Dictionary<int, decimal> d = new Dictionary<int, decimal>();
            Dictionary<int, IVertex> previous = new Dictionary<int, IVertex>();

            foreach (var item in GraphLogic.Vertexes)
            {
                d.Add(item.VertexIdentifier, int.MaxValue);
                previous.Add(item.VertexIdentifier, null);
            }

            d[vertexA.VertexIdentifier] = 0;
            List<IVertex> queue = GraphLogic.Vertexes.ToList();
            IVertex next = null;
            List<int> neighbours;
            //tood make it look nice
            while (queue.Count > 0)
            {
                next = queue.First();
                queue.RemoveAt(0);
                foreach (IVertex neighbour in GraphLogic.GetNeighbours(next))
                {
                    if (d[neighbour.VertexIdentifier] > d[next.VertexIdentifier] + weightFunction(GraphLogic.GetSegment(next, neighbour)))
                    {
                        d[neighbour.VertexIdentifier] = d[next.VertexIdentifier] + weightFunction(GraphLogic.GetSegment(next, neighbour));
                        previous[neighbour.VertexIdentifier] = next;
                        queue.Add(neighbour);
                    }
                }
            }
            Itinerary itinerary = new Itinerary();

            IVertex currentElement = vertexB;
            //tood make it look nice
            while (!currentElement.Equals(vertexA))
            {
                // returnList.Add(currentElement);
                if (previous[currentElement.VertexIdentifier] != null)
                {
                    itinerary.Segments.Add(GraphLogic.GetSegment(previous[currentElement.VertexIdentifier], currentElement));
                    currentElement = previous[currentElement.VertexIdentifier];
                }
                else
                {
                    itinerary.Segments = new List<ISegment>();
                    return itinerary;
                }
            }

            return itinerary;
        }
    }
}