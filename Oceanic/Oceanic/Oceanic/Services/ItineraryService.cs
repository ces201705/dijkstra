using Oceanic.Models;
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
            var segmentModels = GetSegments(model);
            var segments = ConverterHelper.Convert(segmentModels);
            _graphLogic.ApplyGraphSegment(segments);

            var vertex1 = _graphLogic.GetVertexByIdentifier(model.StartLocation.Id);
            var vertex2 = _graphLogic.GetVertexByIdentifier(model.EndLocation.Id);

            return _itineraryFinder.GetItinerary(vertex1, vertex2, x => x.SegmentValues.Time);
        }

        private IList<SegmentModel> GetSegments(SearchViewModel model)
        {
            var segments = _segmentRepository.GetSegmentsForSearch(model.Weight, GetMaxSize(model));
            return segments;
        }

        private int GetMaxSize(SearchViewModel model)
        {
            return new List<int>()
            {
                model.Depth,
                model.Height,
                model.Width
            }.Max();
        }
    }
}