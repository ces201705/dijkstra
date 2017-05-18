using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImpl.UnitTests

{
    /// <summary>
    /// Vertex implementation
    /// </summary>
    public interface IVertex
    {
        /// <summary>
        /// Vertex identifier
        /// </summary>
        int VertexIdentifier
        {
            get;
        }
    }
}