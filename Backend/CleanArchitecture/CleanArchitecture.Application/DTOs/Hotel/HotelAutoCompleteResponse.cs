using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Hotel
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class BMaxLosData
    {
        public int has_extended_los { get; set; }
        public int extended_los { get; set; }
        public string experiment { get; set; }
        public int default_los { get; set; }
        public int is_fullon { get; set; }
        public int max_allowed_los { get; set; }
    }

    public class HotelAutoCompleteResponse
    {
        public string timezone { get; set; }
        public double latitude { get; set; }
        public string label { get; set; }
        public int nr_hotels { get; set; }
        public double longitude { get; set; }
        public string city_name { get; set; }
        public int rtl { get; set; }
        public int? city_ufi { get; set; }
        public string dest_type { get; set; }
        public string dest_id { get; set; }
        public int hotels { get; set; }
        public string lc { get; set; }
        public string country { get; set; }
        public BMaxLosData b_max_los_data { get; set; }
        public string roundtrip { get; set; }
        public string name { get; set; }
        public string cc1 { get; set; }
        public string image_url { get; set; }
        public string region { get; set; }
        public string type { get; set; }
    }


}
