using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oceanic.Models;

namespace Oceanic.DAL
{
    public interface ISegmentRepository
    {
        IList<SegmentModel> GetSegmentsForSearch(decimal weight);
    }
    public class SegmentRepository : BaseRepository<Segment>, ISegmentRepository
    {
        public SegmentRepository(Entities context) : base(context)
        {
        }

        public IList<SegmentModel> GetSegmentsForSearch(decimal weight)
        {
            var price = GetPrice(weight);
            return (from s in Context.Segments
                    join sl in Context.Locations on s.StartLocationId equals sl.Id
                    join el in Context.Locations on s.EndLocationId equals el.Id
                    select new SegmentModel
                    {
                        SourceLocationName = sl.Name,
                        EndLocationName = el.Name,
                        Price = price,
                        Time = (decimal) s.Time
                    })
                .ToList();
        }

        private decimal GetPrice(decimal weight)
        {
            if (weight <= 1)
            {
                return 10;
            }
            else if (weight > 1 && weight <= 5)
            {
                return 15;
            }
            else if (weight > 5 && weight <= 25)
            {
                return 20;
            }
            return 150;
        }
    }
}