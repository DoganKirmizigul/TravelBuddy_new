using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public partial class FlightSearch
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string OperatingCarrier { get; set; }
        public decimal? TravelerPrices { get; set; }
        public string DeparturedAt { get; set; }
        public string ArrivedAt { get; set; }
        public string SearchedBy { get; set; }
        public DateTime? SearchDateTime { get; set; }

    }
}
