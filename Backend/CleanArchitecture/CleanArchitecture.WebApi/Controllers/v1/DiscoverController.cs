using CleanArchitecture.Core.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Core.Features.Categories.Queries.GetAllCategories;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoverController : BaseApiController
    {
        private readonly IDiscoverService _service;

        public DiscoverController(IDiscoverService service)
        {
            _service = service;
        }

        [HttpGet("data")]
        public async Task<IActionResult> Data()
        {
            return Ok(await _service.DiscoverData());
        }
    }
}