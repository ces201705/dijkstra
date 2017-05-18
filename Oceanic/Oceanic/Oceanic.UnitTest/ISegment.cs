using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImpl.UnitTests

{
    /// <summary>
    /// List of segment values.
    /// </summary>
    public class SegmentValues
    {
        /// <summary>
        /// Time value.
        /// </summary>
        public int Time
        {
            get; set;
        }

        /// <summary>
        /// Cost value.
        /// </summary>
        public int Cost
        {
            get; set;
        }
    }

    /// <summary>
    /// Segment implementation
    /// </summary>
    public interface ISegment
    {
        /// <summary>
        /// Start vertex of segment
        /// </summary>
        IVertex VertexStart
        {
            get;
        }

        /// <summary>
        /// End vertex of segment
        /// </summary>
        IVertex VertexEnd
        {
            get;
        }

        /// <summary>
        /// Class of values
        /// </summary>
        SegmentValues SegmentValues
        {
            get;
        }
    }
}