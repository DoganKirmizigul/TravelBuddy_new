using CleanArchitecture.Core.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAdminService
    {
        public Task<AdminDataResponse> AdminData();
    }
}