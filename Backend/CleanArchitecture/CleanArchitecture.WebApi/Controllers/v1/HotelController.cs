using CleanArchitecture.Core.DTOs.Hotel;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelController(IHotelService service, IAuthenticatedUserService authenticatedUser)
        {
            _service = service;
        }

        [HttpGet("auto-complete")]
        public async Task<IActionResult> AutoComplete([FromQuery] string query)
        {
            return Ok(await _service.HotelAutoCompleteSearch(query));
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(HotelSearchRequest hotelSearchRequest)
        {
            return Ok(await _service.HotelSearch(hotelSearchRequest));
        }
    }
}
