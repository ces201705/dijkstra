using Oceanic.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceanic.Dijkstra
{
    public static class ConverterHelper
    {
        public static ISegment Convert(SegmentModel segment)
        {
            Vertex vertexStart = new Vertex();
            vertexStart.VertexIdentifier = segment.StartLocationId;
            vertexStart.Name = segment.StartLocation.Name;

            Vertex vertexEnd = new Vertex();
            vertexEnd.VertexIdentifier = segment.EndLocationId;
            vertexEnd.Name = segment.EndLocation.Name;

            SegmentValues segmentValues = new SegmentValues();
            segmentValues.Cost = segment.Price;
            segmentValues.Time = segment.Time;
            segmentValues.Provider = segment.ProviderName;
            Segment returnItem = new Segment(vertexStart, vertexEnd, segmentValues);

            return returnItem;
        }

        public static IList<ISegment> Convert(IList<SegmentModel> segments)
        {
            return segments.Select(Convert).ToList();
        }
    }
}
