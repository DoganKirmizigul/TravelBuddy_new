using CleanArchitecture.Core.DTOs.Flight;
using CleanArchitecture.Core.DTOs.Rental;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _service;
        public RentalController(IRentalService service)
        {
            _service = service;
        }

        [HttpGet("auto-complete")]
        public async Task<IActionResult> AutoComplete([FromQuery] string query)
        {
            return Ok(await _service.RenatalAutoCompleteSearch(query));
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(RentalSearchRequest hotelSearchRequest)
        {
            return Ok(await _service.RentalSearch(hotelSearchRequest));
        }
    }
}
