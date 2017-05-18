using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public interface IGraphRoute
    {
        IVertex VertexA
        {
            get;
        }

        IVertex VertexB
        {
            get;
        }

        RouteValues RouteValues
        {
            get;
        }
    }
}