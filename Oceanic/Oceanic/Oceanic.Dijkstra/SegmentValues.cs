using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    /// <summary>
    /// List of segment values.
    /// </summary>
    public class SegmentValues
    {
        /// <summary>
        /// Time value.
        /// </summary>
        public decimal Time
        {
            get;
            set;
        }

        /// <summary>
        /// Cost value.
        /// </summary>
        public decimal Cost
        {
            get;
            set;
        }

        /// <summary>
        /// Name of company
        /// </summary>
        public string Provider
        {
            get;
            set;
        }
    }
}