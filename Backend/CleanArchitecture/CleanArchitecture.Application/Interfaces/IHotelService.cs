using CleanArchitecture.Core.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IHotelService
    {
        public Task<List<HotelAutoCompleteResponse>> HotelAutoCompleteSearch(string query);
        Task<HotelSearchResponse> HotelSearch(HotelSearchRequest inputRequest);
    }
}
