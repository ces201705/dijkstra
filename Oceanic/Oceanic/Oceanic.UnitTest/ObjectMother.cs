using System.Collections.Generic;
using Oceanic.DAL;
using Oceanic.DAL.Models;

namespace UnitTests
{
    public class ObjectMother
    {
        public List<LocationModel> CreateCities()
        {
            return new List<LocationModel>
            {
                new LocationModel
                {
                    Id = 0,
                    Name = "Kapsztad"
                },
                new LocationModel
                {
                    Id = 1,
                    Name = "Durban"
                },
                new LocationModel
                {
                    Id = 2,
                    Name = "Johannesburg"
                },
                new LocationModel
                {
                    Id = 3,
                    Name = "Soweto"
                },
                new LocationModel
                {
                    Id = 4,
                    Name = "Pretoria"
                },
                new LocationModel
                {
                    Id = 5,
                    Name = "Port Elizabeth"
                },
                new LocationModel
                {
                    Id = 6,
                    Name = "Pietermaritzburg"
                },
                new LocationModel
                {
                    Id = 7,
                    Name = "Benoni"
                }
            };
        }

        public List<SegmentModel> CreateRoutes()
        {
            var cities = CreateCities();
            return new List<SegmentModel>
            {
                new SegmentModel
                {
                    Id = 1,
                    StartLocation = cities[0],
                    StartLocationId = cities[0].Id,
                    EndLocation = cities[1],
                    EndLocationId = cities[1].Id,
                    Price = 10,
                    Time = 20
                },
                new SegmentModel
                {
                    Id = 2,
                    StartLocation = cities[0],
                    StartLocationId = cities[0].Id,
                    EndLocationId = cities[4].Id,
                    EndLocation = cities[4],
                    Price = 10,
                    Time = 60
                },
                new SegmentModel
                {
                    Id = 3,
                    StartLocation = cities[0],
                    StartLocationId = cities[0].Id,
                    EndLocationId = cities[2].Id,
                    EndLocation = cities[2],
                    Price = 20,
                    Time = 50
                },
                new SegmentModel
                {
                    Id = 4,
                    StartLocation = cities[1],
                    StartLocationId = cities[1].Id,
                    EndLocationId = cities[6].Id,
                    EndLocation = cities[6],
                    Price = 7,
                    Time = 25
                },
                new SegmentModel
                {
                    Id = 5,
                    StartLocation = cities[7],
                    StartLocationId = cities[7].Id,
                    EndLocationId = cities[6].Id,
                    EndLocation = cities[6],
                    Price = 5,
                    Time = 30
                },
                new SegmentModel
                {
                    Id = 6,
                    StartLocation = cities[7],
                    StartLocationId = cities[7].Id,
                    EndLocationId = cities[2].Id,
                    EndLocation = cities[2],
                    Price = 100,
                    Time = 10
                },
                new SegmentModel
                {
                    Id = 7,
                    StartLocation = cities[7],
                    StartLocationId = cities[7].Id,
                    EndLocationId = cities[5].Id,
                    EndLocation = cities[5],
                    Price = 15,
                    Time = 15
                },
                new SegmentModel
                {
                    Id = 8,
                    StartLocation = cities[3],
                    StartLocationId = cities[3].Id,
                    EndLocationId = cities[5].Id,
                    EndLocation = cities[5],
                    Price = 40,
                    Time = 35
                },
                new SegmentModel
                {
                    Id = 9,
                    StartLocation = cities[3],
                    StartLocationId = cities[3].Id,
                    EndLocationId = cities[2].Id,
                    EndLocation = cities[2],
                    Price = 15,
                    Time = 40
                },
                new SegmentModel
                {
                    Id = 10,
                    StartLocation = cities[4],
                    StartLocationId = cities[4].Id,
                    EndLocationId = cities[5].Id,
                    EndLocation = cities[5],
                    Price = 250,
                    Time = 10
                }
            };
        }
    }
}