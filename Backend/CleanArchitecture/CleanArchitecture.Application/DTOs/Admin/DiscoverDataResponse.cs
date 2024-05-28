using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Discover
{
    public class DiscoverDataResponse
    {
        public DiscoverDataResponse() { }

        public DiscoverData Data { get; set; }
    }

    public class DiscoverData
    {
        public DiscoverData() { }

        public List<DiscoverProduct> Products { get; set; }
    }

    public class DiscoverProduct
    {
        public string id { get; set; }
        public string CityName { get; set; }
    }

    public class DiscoverDataDetailResponse
    {
        public DiscoverDataDetail Data { get; set; }

        public class DiscoverDataDetail
        {
            public List<DiscoverProductDetail> Products { get; set; }
        }

        public class DiscoverProductDetail
        {
            public string Id { get; set; }
            public PrimaryPhoto PrimaryPhoto { get; set; }
            public string ShortDescription { get; set; }
            public string Name { get; set; }
            public string CityName { get; set; }

        }

        public class PrimaryPhoto
        {
            public string Small { get; set; }
        }
    }

}