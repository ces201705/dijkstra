using System;
using System.Collections.Generic;
using System.Linq;

namespace Oceanic.Dijkstra
{
    public class GraphLogic : IGraphLogic
    {
        public Dictionary<int, ConcreteVertexData> VertexesData
        {
            get;
            set;
        }

        private Dictionary<int, IVertex> vertexesDictionary;

        private Dictionary<int, IVertex> VertexesDictionary
        {
            get
            {
                if (vertexesDictionary == null)
                {
                    vertexesDictionary = VertexesData.Values.Select(x => x.VertexFrom).ToDictionary(y => y.VertexIdentifier, z => z);
                }
                return vertexesDictionary;
            }
        }

        public List<IVertex> Vertexes

        {
            get
            {
                return VertexesDictionary.Values.ToList();
            }
        }

        public GraphLogic()
        {
            VertexesData = new Dictionary<int, ConcreteVertexData>();
        }

        public void ApplyGraphSegment(IEnumerable<ISegment> routes)
        {
            foreach (var graphRoute in routes)
            {
                ConcreteVertexData concreteVertexDataA = new ConcreteVertexData(graphRoute.VertexStart);

                if (!VertexesData.ContainsKey(graphRoute.VertexStart.VertexIdentifier))
                {
                    VertexesData.Add(graphRoute.VertexStart.VertexIdentifier, concreteVertexDataA);
                }
                VertexesData[graphRoute.VertexStart.VertexIdentifier].ApplyGraphRoute(graphRoute);

                ConcreteVertexData concreteVertexDataB = new ConcreteVertexData(graphRoute.VertexEnd);

                if (!VertexesData.ContainsKey(graphRoute.VertexEnd.VertexIdentifier))
                {
                    VertexesData.Add(graphRoute.VertexEnd.VertexIdentifier, concreteVertexDataB);
                }
                VertexesData[graphRoute.VertexEnd.VertexIdentifier].ApplyGraphRoute(graphRoute, true);
            }
        }

        public ISegment GetSegment(IVertex A, IVertex B)
        {
            return VertexesData[A.VertexIdentifier].RoutesFrom[B.VertexIdentifier];
        }

        public List<IVertex> GetNeighbours(IVertex A)
        {
            return VertexesData[A.VertexIdentifier].Neighbours;
        }

        public IVertex GetVertexByIdentifier(int vertexIdentifier)
        {
            return VertexesDictionary[vertexIdentifier];
        }

        public IVertex GetVertexByIdentifier(int vertexIdentifier)
        {
            return VertexesDictionary[vertexIdentifier];
        }
    }
}