using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public class GraphRoute : IGraphRoute
    {
        public RouteValues RouteValues

        {
            get;
        }

        public IVertex VertexA
        {
            get;
        }

        public IVertex VertexB
        {
            get;
        }

        public GraphRoute(IVertex vertexA, IVertex vertexB, RouteValues routeValues)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            RouteValues = routeValues;
        }
    }
}