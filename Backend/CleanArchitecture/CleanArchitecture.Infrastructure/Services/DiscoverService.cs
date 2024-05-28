using CleanArchitecture.Core.DTOs.Discover;
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
    public class DiscoverService : IDiscoverService
    {

        private IConfiguration _configuration;
        private ProductDbContext _context;
        private ApplicationDbContext _applicationDb;
        private IAuthenticatedUserService _authenticatedUser;

        public DiscoverService(IConfiguration configuration, ProductDbContext context, ApplicationDbContext applicationDb, IAuthenticatedUserService authenticatedUser)
        {
            _configuration = configuration;
            _context = context;
            _authenticatedUser = authenticatedUser;
            _applicationDb = applicationDb;
        }

        public async Task<List<DiscoverDataDetailResponse.DiscoverProductDetail>> DiscoverData()
        {
            var finalResult = new List<DiscoverDataDetailResponse.DiscoverProductDetail>();

            var lastSearch = _context.FlightSearches.OrderByDescending(o => o.SearchDateTime).FirstOrDefault();
            var city = "";
            if (lastSearch != null)
            {
                city = lastSearch.To;
            }
            else
            {
                city = "new york";
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/attraction/auto-complete?query={city}"),
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
                var result = JsonConvert.DeserializeObject<DiscoverDataResponse>(body);

                if (result != null && result.Data != null && result.Data.Products != null)
                {
                    foreach (var product in result.Data.Products)
                    {
                        request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri($"https://booking-com18.p.rapidapi.com/attraction/search?id={product.id}"),
                            Headers =
                            {
                                { "X-RapidAPI-Key", _configuration.GetValue<string>("RapidAPIKey") },
                                { "X-RapidAPI-Host", "booking-com18.p.rapidapi.com" },
                            },
                        };
                        using (var res = await client.SendAsync(request))
                        {
                            res.EnsureSuccessStatusCode();
                            body = await res.Content.ReadAsStringAsync();
                            var result2 = JsonConvert.DeserializeObject<DiscoverDataDetailResponse>(body);

                            if (result2 != null && result2.Data != null && result2.Data.Products != null)
                            {
                                foreach (var item in result2.Data.Products)
                                {
                                    finalResult.Add(new DiscoverDataDetailResponse.DiscoverProductDetail()
                                    {
                                        Id = item.Id,
                                        CityName = product.CityName,
                                        Name = item.Name,
                                        ShortDescription = item.ShortDescription,
                                        PrimaryPhoto = new DiscoverDataDetailResponse.PrimaryPhoto()
                                        {
                                            Small = item.PrimaryPhoto.Small,
                                        }
                                    });
                                }
                            }
                        }
                    }
                }
                //https://booking-com18.p.rapidapi.com/attraction/search?id=eyJ1ZmkiOjIwMDg4MzI1fQ%3D%3D
                return finalResult;
            }
        }

    }
}