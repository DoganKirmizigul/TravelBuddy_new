using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public partial class HotelSearch
    {
        public string Id { get; set; }
        public string LocationId { get; set; }
        public DateTime? CheckinDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public decimal? ReviewScore { get; set; }
        public string Currency { get; set; }
        public string Price { get; set; }
        public string SearchedBy { get; set; }
        public DateTime? SearchDateTime { get; set; }
    }
}
