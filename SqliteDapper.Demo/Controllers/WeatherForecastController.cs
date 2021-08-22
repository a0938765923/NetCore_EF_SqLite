using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static SqliteDapper.Demo.Startup;

namespace SqliteDapper.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IConfiguration _config;
        //private Startup.AppSetting _appSetting;
        //public AppSetting _appSetting { get; set; }


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
          

            //this._config = config;
            //this._appSetting = options.Value;

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var defaultCulture = _config["SupportedCultures:1"]; // defaultCulture = "zh-TW"
            var subProperty1 = _config["CustomObject:Property:SubProperty1"]; // subProperty1 = "1"
            var subProperty2 = _config["CustomObject:Property:SubProperty2"]; // subProperty2 = "True"
            var subProperty3 = _config["CustomObject:Property:SubProperty3"]; // subProperty3 = "This is sub property."

            Console.WriteLine("--------------this is my setting.json-----------------");
            Console.WriteLine(defaultCulture);
            Console.WriteLine(subProperty1);
            Console.WriteLine(subProperty2);
            Console.WriteLine(subProperty3);
            Console.WriteLine("-------------------------------");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
