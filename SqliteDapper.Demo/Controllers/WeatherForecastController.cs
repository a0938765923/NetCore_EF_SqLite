using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        private Startup.AppSetting _appSetting;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config, IOptions<Startup.AppSetting> options)
        {
            _logger = logger;
            this._config = config;
            this._appSetting = options.Value;

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Console.WriteLine("-----------------WeatherForcecastController--------------------");
            Console.WriteLine($"AppId = {_config["Player:AppId"]}");
            Console.WriteLine($"AppId = {_config["Player:Key"]}");
            Console.WriteLine($"AppId = {_config["Player:name"]}");
            Console.WriteLine("APPseting"+ _appSetting);
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
