using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Oceanic.DAL.Models;
using Oceanic.Dijkstra;

namespace UnitTests
{
    [TestClass]
    public class AlgorithmLogicTests : BaseTest
    {
        private List<int> Act(List<SegmentModel> segments, int a, int b, Func<ISegment, decimal> weightFunction)
        {
            GraphLogic graph = new GraphLogic();
            graph.ApplyGraphSegment(segments.Select(ConverterHelper.Convert));
            ItineraryFinder algorithm = new ItineraryFinder(graph);
            var vertex1 = algorithm.GraphLogic.GetVertexByIdentifier(a);
            var vertex2 = algorithm.GraphLogic.GetVertexByIdentifier(b);

            var result = algorithm.GetItinerary(vertex1, vertex2, weightFunction);
            var starts = result.Segments.Select(x => x.VertexStart.VertexIdentifier).ToList();
            var ends = result.Segments.Select(x => x.VertexEnd.VertexIdentifier).ToList();
            return ends.Concat(starts).Distinct().ToList();
        }

        [TestMethod]
        public void CountRoute_ShouldBe3Localizations()
        {
            List<SegmentModel> routes = ObjectMother.CreateRoutes();

            var result = Act(routes, 4, 3, x => x.SegmentValues.Time);

            AssertResult(result, 3, 5, 4);
        }

        [TestMethod]
        public void CountRoute_ShouldBe4Localizations()
        {
            List<SegmentModel> routes = ObjectMother.CreateRoutes();

            var result = Act(routes, 4, 3, x => x.SegmentValues.Cost);

            AssertResult(result, 3, 2, 0, 4);
        }

        [TestMethod]
        public void CountRoute_ShouldBe2Localizations()
        {
            List<SegmentModel> routes = ObjectMother.CreateRoutes();

            var result = Act(routes, 4, 5, x => x.SegmentValues.Time);

            AssertResult(result, 4, 5);
        }

        [TestMethod]
        public void CountRoute_ShouldBe6Localizations()
        {
            List<SegmentModel> routes = ObjectMother.CreateRoutes();

            var result = Act(routes, 4, 5, x => x.SegmentValues.Cost);

            AssertResult(result, 4, 0, 1, 6, 7, 5);
        }

        [TestMethod]
        public void CountRoute_Optimal_ShouldBe2Localizations()
        {
            List<SegmentModel> routes = ObjectMother.CreateRoutes();

            var result = Act(routes, 4, 5, x => x.SegmentValues.Cost + x.SegmentValues.Time*3 );

            AssertResult(result, 4, 5);
        }


        [TestMethod]
        public void CountRoute_Optimal_ShouldBe0Localizations()
        {
            List<SegmentModel> routes = ObjectMother.CreateRoutes();

            var result = Act(routes, 4, 4, x => x.SegmentValues.Cost);

            AssertResult(result);
        }

        private void AssertResult(List<int> result, params int[] locations)
        {
            foreach (var location in locations)
            {
                Assert.IsTrue(result.Any(x => x == location), $"Location {location} not found");
            }
            Assert.AreEqual(locations.Length, result.Count);
        }
    }
}