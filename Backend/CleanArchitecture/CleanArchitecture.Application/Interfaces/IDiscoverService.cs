using CleanArchitecture.Core.DTOs.Admin;
using CleanArchitecture.Core.DTOs.Discover;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IDiscoverService
    {
        public Task<List<DiscoverDataDetailResponse.DiscoverProductDetail>> DiscoverData();
    }
}