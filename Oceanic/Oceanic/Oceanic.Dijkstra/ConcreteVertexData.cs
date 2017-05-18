using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public class ConcreteVertexData
    {
        public ConcreteVertexData(IVertex vertexFrom)
        {
            VertexFrom = vertexFrom;
            RoutesFrom = new Dictionary<int, ISegment>();
            Neighbours = new List<IVertex>();
        }

        public IVertex VertexFrom
        {
            get;
            set;
        }

        public Dictionary<int, ISegment> RoutesFrom
        {
            get;
            set;
        }

        public List<IVertex> Neighbours
        {
            get;
            set;
        }

        public void ApplyGraphRoute(ISegment segment, bool changeDirection = false)
        {
            if (!changeDirection)
            {
                RoutesFrom.Add(segment.VertexEnd.VertexIdentifier, segment);
                Neighbours.Add(segment.VertexEnd);
            }
            else
            {
                RoutesFrom.Add(segment.VertexStart.VertexIdentifier, segment);
                Neighbours.Add(segment.VertexStart);
            }
        }
    }
}