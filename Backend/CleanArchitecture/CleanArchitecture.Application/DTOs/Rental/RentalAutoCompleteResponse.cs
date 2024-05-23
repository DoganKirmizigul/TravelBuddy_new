using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Rental
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Coordinates
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }

    public class Datum
    {
        public Coordinates coordinates { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public object city_id { get; set; }
        public string iata_code { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public object location_id { get; set; }
        public string id { get; set; }
    }

    public class RentalAutoCompleteResponse
    {
        public List<Datum> data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

}
