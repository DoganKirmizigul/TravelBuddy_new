using CleanArchitecture.Core.DTOs.Flight;
using CleanArchitecture.Core.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IFlightService
    {
        public Task<FlightAutoCompleteResponse> FlightAutoCompleteSearch(string query);

        public Task<FlightSearchResponse> FlightSearch(FlightSearchRequest inputRequest);
    }
}
