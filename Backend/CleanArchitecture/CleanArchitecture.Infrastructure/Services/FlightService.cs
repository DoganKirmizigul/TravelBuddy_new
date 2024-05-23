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
    public class FlightService : IFlightService
    {

        private IConfiguration _configuration;
        private ProductDbContext _context;
        private IAuthenticatedUserService _authenticatedUser;

        public FlightService(IConfiguration configuration, ProductDbContext context, IAuthenticatedUserService authenticatedUser)
        {
            _configuration = configuration;
            _context = context;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<FlightAutoCompleteResponse> FlightAutoCompleteSearch(string query)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/flights/auto-complete?query={query}"),
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
                return JsonConvert.DeserializeObject<FlightAutoCompleteResponse>(body);
            }
        }

        public async Task<FlightSearchResponse> FlightSearch(FlightSearchRequest inputRequest)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/flights/search-oneway?fromId={inputRequest.From}&toId={inputRequest.To}&departureDate={inputRequest.DepartureDate.ToString("yyyy-MM-dd")}&nonstopFlightsOnly=false&numberOfStops=maximum_allone_stop"),
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
                var result = JsonConvert.DeserializeObject<FlightSearchResponse>(body);
                if(result != null && result?.data?.flights != null && result.data?.flights.Count > 0)
                {
                    foreach(var item in result?.data?.flights)
                    {
                        var model = new FlightSearch
                        {
                            Id = System.Guid.NewGuid().ToString(),
                            From = inputRequest.From,
                            To = inputRequest.To,
                            DepartureDate = inputRequest.DepartureDate,
                            OperatingCarrier = item?.bounds[0]?.segments[0]?.operatingCarrier?.name,
                            TravelerPrices = item?.travelerPrices[0]?.price?.price?.value,
                            DeparturedAt = item?.bounds[0]?.segments[0]?.departuredAt,
                            ArrivedAt = item?.bounds[0]?.segments[0]?.arrivedAt,
                            SearchedBy = _authenticatedUser.UserId,
                            SearchDateTime = DateTime.Now,
                        };
                        _context.FlightSearches.Add(model);
                        _context.SaveChanges();
                    }
                }
                return result;
            }
        }
    }
}
