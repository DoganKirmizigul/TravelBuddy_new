using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Admin
{
    public class AdminDataResponse
    {
        public AdminDataResponse() { }

        public int UsersCount { get; set; }
        public int SearchesCount { get; set; }
        public List<AdminMostSearch> MostSearchedHotels { get; set; } = new List<AdminMostSearch>();
        public List<AdminMostSearch> MostSearchedFlights { get; set; } = new List<AdminMostSearch>();
        public List<AdminMostSearch> MostSearchedRentals { get; set; } = new List<AdminMostSearch>();
    }

    public class AdminMostSearch
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}