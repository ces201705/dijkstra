﻿using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oceanic.DAL;
using Oceanic.ViewModel;
using Oceanic.DAL.Models;
using Oceanic.Dijkstra;

namespace Oceanic.Services
{
    public interface IItineraryService
    {
        IItinerary FindItinerary(SearchViewModel model);
    }

    public class ItineraryService : IItineraryService
    {
        private ISegmentRepository _segmentRepository;
        private IItineraryFinder _itineraryFinder;
        private IGraphLogic _graphLogic;

        public ItineraryService(ISegmentRepository segmentRepository, IItineraryFinder iItineraryFinder, IGraphLogic graphLogic)
        {
            _segmentRepository = segmentRepository;
            _itineraryFinder = iItineraryFinder;
            _graphLogic = graphLogic;
        }

        public IItinerary FindItinerary(SearchViewModel model)
        {
            _graphLogic = new GraphLogic();
            _itineraryFinder = new ItineraryFinder(_graphLogic);
            var segmentModels = GetSegments(model);
            var segments = ConverterHelper.Convert(segmentModels);
            _graphLogic.ApplyGraphSegment(segments);

            var vertex1 = _graphLogic.GetVertexByIdentifier(model.StartLocationId);
            var vertex2 = _graphLogic.GetVertexByIdentifier(model.EndLocationId);
            if (vertex1 == null || vertex2 == null)
            {
                return new Itinerary()
                {
                    IsValid = true,
                    Segments = new List<ISegment>()
                };
            }
            var weightFunc = GetweightFunction(model);

            var result = _itineraryFinder.GetItinerary(vertex1, vertex2, weightFunc);

            return FixOrder(result, model);
        }

        private IItinerary FixOrder(IItinerary result, SearchViewModel model)
        {
            if (!result.Segments.Any())
            {
                return result;
            }
            result.Segments.Reverse();
            if (result.Segments[0].VertexStart.VertexIdentifier != model.StartLocationId)
            {
                var temp = result.Segments[0].VertexStart;
                result.Segments[0].VertexStart = result.Segments[0].VertexEnd;
                result.Segments[0].VertexEnd = temp;
            }
            for (int i = 1; i < result.Segments.Count; i++)
            {
                if (result.Segments[i].VertexStart.VertexIdentifier != result.Segments[i-1].VertexEnd.VertexIdentifier)
                {
                    var temp = result.Segments[i].VertexStart;
                    result.Segments[i].VertexStart = result.Segments[i].VertexEnd;
                    result.Segments[i].VertexEnd = temp;
                }
            }
            return result;
        }

        private IList<SegmentModel> GetSegments(SearchViewModel model)
        {
            Entities context = new Entities();
            List<Location> locations = context.Location.ToList();
            var segments = _segmentRepository.GetSegmentsForSearch(model.Weight.Value, GetMaxSize(model));

            //List<TestSegment> telstarSegments = ExternalServiceHelper.GetTestSegments();
            //foreach (TestSegment segment in telstarSegments)
            //{
            //    Location startLocation = locations.FirstOrDefault(o => o.Name.ToLower().Trim() == segment.SourceLocationName.ToLower().Trim());
            //    if (startLocation == null)
            //    {
            //        continue;
            //    }

            //    Location endLocation = locations.FirstOrDefault(o => o.Name.ToLower().Trim() == segment.EndLocationName.ToLower().Trim());
            //    if (endLocation == null)
            //    {
            //        continue;
            //    }

            //    SegmentModel segmentModel = new SegmentModel();
            //    segmentModel.StartLocation = new LocationModel() { Id = startLocation.Id, Name = startLocation.Name };
            //    segmentModel.EndLocation = new LocationModel() { Id = endLocation.Id, Name = endLocation.Name };
            //    segmentModel.Price = segment.Price;
            //    segmentModel.Time = segment.Time;
            //    segments.Add(segmentModel);
            //}

            List<TelstarSegment> telstarSegments = ExternalServiceHelper.GetTelstarSegments();
            foreach (TelstarSegment segment in telstarSegments)
            {
                Location startLocation = locations.FirstOrDefault(o => o.Name.ToLower().Trim() == segment.SourceLocationName.ToLower().Trim());
                if (startLocation == null)
                {
                    continue;
                }

                Location endLocation = locations.FirstOrDefault(o => o.Name.ToLower().Trim() == segment.DestinationLocationName.ToLower().Trim());
                if (endLocation == null)
                {
                    continue;
                }

                SegmentModel segmentModel = new SegmentModel();
                segmentModel.StartLocation = new LocationModel() { Id = startLocation.Id, Name = startLocation.Name };
                segmentModel.StartLocationId = startLocation.Id;
                segmentModel.EndLocation = new LocationModel() { Id = endLocation.Id, Name = endLocation.Name };
                segmentModel.EndLocationId = endLocation.Id;
                segmentModel.Price = segment.Price;
                segmentModel.Time = segment.Time;
                segmentModel.ProviderName = "Telstar";
                segments.Add(segmentModel);
            }

            return segments;
        }

        private int GetMaxSize(SearchViewModel model)
        {
            return new List<int>()
            {
                (int)model.Depth,
                (int)model.Height,
                (int)model.Width
            }.Max();
        }

        private Func<ISegment, decimal> GetweightFunction(SearchViewModel mode)
        {
            switch (mode.ItineraryType)
            {
                case ItineraryType.Cheapest:
                    return x => x.SegmentValues.Cost;
                case ItineraryType.Fastest:
                    return x => x.SegmentValues.Time;
                case ItineraryType.Optimal:
                    return x => 0.4m * x.SegmentValues.Time + 0.6m * x.SegmentValues.Cost;
                default:
                    return x => x.SegmentValues.Time;
            }
        }
    }
}