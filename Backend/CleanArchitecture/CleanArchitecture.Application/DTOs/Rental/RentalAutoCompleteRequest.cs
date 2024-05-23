using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Rental
{
    public class RentalAutoCompleteRequest
    {
        [Required]
        public string Query { get; set; }
    }
}
