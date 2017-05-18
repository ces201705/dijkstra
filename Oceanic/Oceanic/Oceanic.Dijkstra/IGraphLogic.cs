using System;
using System.Collections.Generic;

namespace Oceanic.Dijkstra
{
    /// <summary>
    /// Implementation of graph logic.
    /// </summary>
    public interface IGraphLogic
    {
        /// <summary>
        /// Get segment between two vertexes.
        /// </summary>
        /// <param name="A">Start vertex of segment</param>
        /// <param name="B">End vertex of segment</param>
        /// <returns></returns>
        ISegment GetSegment(IVertex A, IVertex B);

        /// <summary>
        /// Get neighbours of vertex
        /// </summary>
        /// <param name="A">Vertex of A</param>
        /// <returns></returns>
        List<IVertex> GetNeighbours(IVertex A);

        /// <summary>
        /// List of vertexes in graph.
        /// </summary>
        List<IVertex> Vertexes
        {
            get;
        }

        /// <summary>
        /// Get vertex by vertex identifier
        /// </summary>
        /// <param name="vertexIdentifier"></param>
        /// <returns></returns>
        IVertex GetVertexByIdentifier(int vertexIdentifier);
    }
}