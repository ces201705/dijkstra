using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Oceanic.DAL.Models;

namespace Oceanic.DAL
{
    public interface ISegmentRepository
    {
        IList<SegmentModel> GetSegmentsForSearch(int parcelWeight, int parcelMaxDimensionSize);
    }
    public class SegmentRepository : BaseRepository<Segment>, ISegmentRepository
    {
        public SegmentRepository(Entities context) : base(context)
        {
        }

        public IList<SegmentModel> GetSegmentsForSearch(int parcelWeight, int parcelMaxDimensionSize)
        {
            if (!Valid(parcelMaxDimensionSize))
            {
                return new List<SegmentModel>();
            }
            var price = GetPrice(parcelWeight);
            return (from s in Context.Segment
                    join sl in Context.Location on s.StartLocationId equals sl.Id
                    join el in Context.Location on s.EndLocationId equals el.Id
                    select new SegmentModel
                    {
                        StartLocationId = sl.Id,
                        StartLocation = new LocationModel()
                        {
                            Id = sl.Id,
                            Name = sl.Name
                        },
                        EndLocationId = el.Id,
                        EndLocation = new LocationModel()
                        {
                            Id = el.Id,
                            Name = el.Name
                        },
                        Price = price,
                        Time = (decimal) s.Time
                    })
                .ToList();
        }

        private bool Valid(int parcelMaxDimensionSize)
        {
            return parcelMaxDimensionSize <= 10;
        }

        private decimal GetPrice(int weight)
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