using CheapAwesome.API.Models;
using CheapAwesome.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheapAwesome.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValentinesBargainsController : ControllerBase
    {
        private readonly IValentinesBargainsService _valentinesBargainsService;

        public ValentinesBargainsController(IValentinesBargainsService valentinesBargainsService)
        {
            _valentinesBargainsService = valentinesBargainsService;
        }

        [HttpGet]
        public async Task<List<HotelInfo>> Get(int destinationId, int nights)
        {
            var results = await _valentinesBargainsService.Find(destinationId, nights);
            return results;
        }
    }
}
