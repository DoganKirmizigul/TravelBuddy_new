using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Hotel
{
    public class HotelAutoCompleteRequest
    {
        [Required]
        public string Query { get; set; }
    }
}
