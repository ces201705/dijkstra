using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public class Segment : ISegment
    {
        public Segment(IVertex vertexStart, IVertex vertexEnd, SegmentValues segmentValues)
        {
            VertexStart = vertexStart;
            VertexEnd = vertexEnd;
            SegmentValues = segmentValues;
        }

        public SegmentValues SegmentValues
        {
            get;
            set;
        }

        public IVertex VertexEnd
        {
            get;
            set;
        }

        public IVertex VertexStart
        {
            get;
            set;
        }
    }
}