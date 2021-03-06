﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public interface ISegment
    {
        IVertex VertexStart { get; set; }

        IVertex VertexEnd { get; set; }

        SegmentValues SegmentValues { get; set; }
    }
}