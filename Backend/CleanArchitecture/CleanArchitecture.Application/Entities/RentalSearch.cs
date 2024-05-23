using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public partial class RentalSearch
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DropOffDate { get; set; }
        public string Currency { get; set; }
        public decimal? Price { get; set; }
        public string PickUpAddress { get; set; }
        public string DropOffAddress { get; set; }
        public string SearchedBy { get; set; }
        public DateTime? SearchDateTime { get; set; }

    }
}