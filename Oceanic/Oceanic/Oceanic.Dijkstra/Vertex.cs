using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public class Vertex : IVertex
    {
        public Vertex()
        {
        }

        public Vertex(Vertex vertex)
        {
            this.VertexIdentifier = vertex.VertexIdentifier;
            this.Name = vertex.Name;
        }

        public int VertexIdentifier
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(IVertex vertex)
        {
            if ((object)vertex == null)
            {
                return false;
            }
            return (this.VertexIdentifier == vertex.VertexIdentifier);
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Vertex p = obj as Vertex;
            if ((System.Object)p == null)
            {
                return false;
            }
            return (this.VertexIdentifier == p.VertexIdentifier);
        }

        public override int GetHashCode()
        {
            return this.VertexIdentifier;
        }
    }
}