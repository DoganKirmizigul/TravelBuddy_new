using CleanArchitecture.Core.DTOs.Flight;
using CleanArchitecture.Core.DTOs.Hotel;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _service;

        public FlightController(IFlightService service)
        {
            _service = service;
        }

        [HttpGet("auto-complete")]
        public async Task<IActionResult> AutoComplete([FromQuery] string query)
        {
            return Ok(await _service.FlightAutoCompleteSearch(query));
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FlightSearchRequest hotelSearchRequest)
        {
            return Ok(await _service.FlightSearch(hotelSearchRequest));
        }
    }
}
