using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsenkronController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Random random;
        public AsenkronController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            random = new Random();

        }

        [HttpGet]
        public async Task<int> GetAsync()
        {
            var delay = random.Next(1000,5000);
            await Task.Delay(delay).ConfigureAwait(false);
            return delay;
        }

    }
}
