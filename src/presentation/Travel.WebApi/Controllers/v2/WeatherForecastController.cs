using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<WeatherForecast> Post(string city)
        {
            var rng = new Random;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                City = city
            }).ToArray();
        }


    }
}
