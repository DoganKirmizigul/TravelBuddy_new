using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Flight
{
    public class Datum
    {
        public string __typename { get; set; }
        public string city { get; set; }
        public string cityCode { get; set; }
        public string continent { get; set; }
        public string continentCode { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string iataCode { get; set; }
        public int id { get; set; }
        public bool multipleAirports { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string type { get; set; }
    }

    public class FlightAutoCompleteResponse
    {
        public List<Datum> data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

}
