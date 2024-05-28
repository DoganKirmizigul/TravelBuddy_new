using CleanArchitecture.Core.DTOs;
using CleanArchitecture.Core.DTOs.Hotel;
using CleanArchitecture.Core.DTOs.Rental;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class HotelService : IHotelService
    {
        private IConfiguration _configuration;
        private ProductDbContext _context;
        private IAuthenticatedUserService _authenticatedUser;
        public HotelService(IConfiguration configuration, ProductDbContext context, IAuthenticatedUserService authenticatedUser)
        {
            _configuration = configuration;
            _context = context;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<List<HotelAutoCompleteResponse>> HotelAutoCompleteSearch(string query)
        {
            List<HotelAutoCompleteResponse> finalResult = new List<HotelAutoCompleteResponse>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={query}&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", _configuration.GetValue<string>("RapidAPIKey") },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                finalResult = JsonConvert.DeserializeObject<List<HotelAutoCompleteResponse>>(body);
            }

            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://sky-scrapper.p.rapidapi.com/api/v1/flights/searchAirport?query={query}"),
                Headers =
                {
                    { "X-RapidAPI-Key", _configuration.GetValue<string>("RapidAPIKey") },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var results = JsonConvert.DeserializeObject<List<HotelAutoCompleteResponse>>(body);
                finalResult.AddRange(results);
            }

            return finalResult;
        }

        public async Task<HotelSearchResponse> HotelSearch(HotelSearchRequest inputRequest)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkout_date={inputRequest.CheckoutDate.ToString("yyyy-MM-dd")}&order_by=popularity&filter_by_currency=USD&room_number=1&dest_id={inputRequest.LocationId}&dest_type=city&adults_number=2&checkin_date={inputRequest.CheckinDate.ToString("yyyy-MM-dd")}&locale=en-us&units=metric&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&children_ages=5%2C0"),
                Headers =
                {
                    { "X-RapidAPI-Key", _configuration.GetValue<string>("RapidAPIKey")},
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var result = JsonConvert.DeserializeObject<HotelSearchResponse>(body);

                if (result != null && result.result?.Count > 0)
                {
                    foreach (var item in result.result)
                    {
                        var model = new HotelSearch
                        {
                            Id = System.Guid.NewGuid().ToString(),
                            LocationId = inputRequest.LocationId,
                            CheckinDate = inputRequest.CheckinDate,
                            CheckoutDate = inputRequest.CheckoutDate,
                            HotelName = item?.hotel_name,
                            Address = item?.address,
                            Photo = item?.max_photo_url,
                            ReviewScore = item?.review_score != null ? ((decimal?)item?.review_score) : null,
                            Currency = item?.price_breakdown?.currency,
                            Price = item?.price_breakdown?.gross_price,
                            SearchedBy = _authenticatedUser.UserId,
                            SearchDateTime = DateTime.Now,
                        };
                        _context.HotelSearches.Add(model);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    var bodyDetail = JsonConvert.DeserializeObject<BodyDetail>(body);
                    if (bodyDetail != null && bodyDetail.detail != null && bodyDetail.detail.Count > 0)
                    {
                        switch (bodyDetail.detail[0].msg)
                        {
                            case "checkout_date is less than checkin_date":
                                result.error = "End Date should be greater than Start Date.";
                                break;
                            default:
                                result.error = bodyDetail.detail[0].msg;
                                break;
                        }

                    }
                    //return body2;
                }

                return result;
            }
        }
    }
}