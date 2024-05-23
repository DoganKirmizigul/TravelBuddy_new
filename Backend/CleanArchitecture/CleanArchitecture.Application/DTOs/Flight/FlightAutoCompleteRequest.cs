using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Flight
{
    public class FlightAutoCompleteRequest
    {
        [Required]
        public string Query { get; set; }
    }
}
