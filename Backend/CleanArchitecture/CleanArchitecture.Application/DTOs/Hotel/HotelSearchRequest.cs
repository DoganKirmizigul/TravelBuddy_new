using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Hotel
{
    public class HotelSearchRequest
    {
        [Required]
        public string LocationId { get; set; }
        [Required]
        public DateTime CheckinDate { get; set; }
        [Required]
        public DateTime CheckoutDate { get; set; }
    }
}
