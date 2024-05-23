using CleanArchitecture.Core.DTOs.Hotel;
using CleanArchitecture.Core.DTOs.Rental;
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
    public class RentalService : IRentalService
    {

        private IConfiguration _configuration;
        private ProductDbContext _context;
        private IAuthenticatedUserService _authenticatedUser;

        public RentalService(IConfiguration configuration, ProductDbContext context, IAuthenticatedUserService authenticatedUser)
        {
            _configuration = configuration;
            _context = context;
            _authenticatedUser = authenticatedUser;
        }


        public async Task<RentalAutoCompleteResponse> RenatalAutoCompleteSearch(string query)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/car/auto-complete?query={query}"),
                Headers =
    {
        { "X-RapidAPI-Key", _configuration.GetValue<string>("RapidAPIKey") },
        { "X-RapidAPI-Host", "booking-com18.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return JsonConvert.DeserializeObject<RentalAutoCompleteResponse>(body);
            }
        }

        public async Task<RentalSearchResponse> RentalSearch(RentalSearchRequest inputRequest)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/car/search?pickUpId={inputRequest.From}&dropOffId={inputRequest.To}&pickUpDate={inputRequest.PickupDate.ToString("yyyy-MM-dd")}&pickUpTime=12%3A00&dropOffDate={inputRequest.DropOffDate.ToString("yyyy-MM-dd")}&dropOffTime=12%3A00"),
                Headers =
    {
        { "X-RapidAPI-Key", _configuration.GetValue<string>("RapidAPIKey") },
        { "X-RapidAPI-Host", "booking-com18.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var result = JsonConvert.DeserializeObject<RentalSearchResponse>(body);
                if(result?.data?.search_results != null && result.data?.search_results?.Count() > 0)
                {
                    foreach(var item in result?.data?.search_results)
                    {
                        var model = new RentalSearch
                        {
                            Id = System.Guid.NewGuid().ToString(),
                            From = inputRequest.From,
                            To = inputRequest.To,
                            PickupDate = inputRequest?.PickupDate,
                            DropOffDate = inputRequest?.DropOffDate,
                            Currency = item?.pricing_info?.base_currency,
                            Price = item?.pricing_info?.drive_away_price != null ? (decimal?)item?.pricing_info?.drive_away_price : null,
                            PickUpAddress = item?.route_info?.pickup.address,
                            DropOffAddress = item?.route_info.dropoff?.address,
                            SearchedBy = _authenticatedUser.UserId,
                            SearchDateTime = DateTime.Now,
                        };

                        _context.RentalSearches.Add(model);
                        _context.SaveChanges();
                    }
                }
                return result;
            }
        }
    }
}
