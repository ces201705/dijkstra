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
                if (!RoutesFrom.ContainsKey(segment.VertexEnd.VertexIdentifier))
                {
                    RoutesFrom.Add(segment.VertexEnd.VertexIdentifier, segment);
                }
                if (!Neighbours.Any(x => x.Equals(segment.VertexEnd)))
                {
                    Neighbours.Add(segment.VertexEnd);
                }
            }
            else
            {
                if (!RoutesFrom.ContainsKey(segment.VertexStart.VertexIdentifier))
                {
                    RoutesFrom.Add(segment.VertexStart.VertexIdentifier, segment);
                }
                if (!Neighbours.Any(x => x.Equals(segment.VertexStart)))
                {
                    Neighbours.Add(segment.VertexStart);
                }
            }
        }
    }
}