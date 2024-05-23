using CleanArchitecture.Core.DTOs.Hotel;
using CleanArchitecture.Core.DTOs.Rental;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRentalService
    {
        public Task<RentalAutoCompleteResponse> RenatalAutoCompleteSearch(string query);
        Task<RentalSearchResponse> RentalSearch(RentalSearchRequest inputRequest);
    }
}
