﻿using System;
using System.Collections.Generic;

namespace Oceanic.Models
{
    public class SearchResultViewModel
    {
        public SearchResultViewModel()
        {
            this.Segments = new List<ResultSegment>();
        }

        public List<ResultSegment> Segments { get; set; }
        public decimal TotalTime { get; set; }
        public decimal TotalPrice { get; set; }
    }


    public class ResultSegment
    {
        public string DepartureLocationName { get; set; }
        public string DestinationLocationName { get; set; }
        public string Provider { get; set; }
        public decimal Time { get; set; }
        public decimal Price { get; set; }
    }
}