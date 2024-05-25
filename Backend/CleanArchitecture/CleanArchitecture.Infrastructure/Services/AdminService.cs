using CleanArchitecture.Core.DTOs.Admin;
using CleanArchitecture.Core.DTOs.Flight;
using CleanArchitecture.Core.DTOs.Hotel;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class AdminService : IAdminService
    {

        private IConfiguration _configuration;
        private ProductDbContext _context;
        private ApplicationDbContext _applicationDb;
        private IAuthenticatedUserService _authenticatedUser;

        public AdminService(IConfiguration configuration, ProductDbContext context, ApplicationDbContext applicationDb, IAuthenticatedUserService authenticatedUser)
        {
            _configuration = configuration;
            _context = context;
            _authenticatedUser = authenticatedUser;
            _applicationDb = applicationDb;
        }

        public async Task<AdminDataResponse> AdminData()
        {
            var adminData = new AdminDataResponse();

            adminData.UsersCount = _applicationDb.Users.Count();
            adminData.SearchesCount = _context.RentalSearches.Count();
            adminData.SearchesCount += _context.FlightSearches.Count();
            adminData.SearchesCount += _context.HotelSearches.Count();

            adminData.MostSearchedHotels = _context.HotelSearches
                .GroupBy(g => g.Address)
                .Select(s => new AdminMostSearch { Name = s.Key, Count = s.Count() })
                .OrderByDescending(o => o.Count)
                .Take(10)
                .ToList();

            adminData.MostSearchedFlights = _context.FlightSearches
                .GroupBy(g => g.From)
                .Select(s => new AdminMostSearch { Name = s.Key, Count = s.Count() })
                .OrderByDescending(o => o.Count)
                .Take(10)
                .ToList();

            adminData.MostSearchedFlights = _context.FlightSearches
                .GroupBy(g => g.To)
                .Select(s => new AdminMostSearch { Name = s.Key, Count = s.Count() })
                .OrderByDescending(o => o.Count)
                .Take(10)
                .ToList();

            adminData.MostSearchedRentals = _context.RentalSearches
                .GroupBy(g => g.DropOffAddress)
                .Select(s => new AdminMostSearch { Name = s.Key, Count = s.Count() })
                .OrderByDescending(o => o.Count)
                .Take(10)
                .ToList();

            return await Task.Run(() => adminData);
        }

    }
}