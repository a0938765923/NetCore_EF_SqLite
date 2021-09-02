using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using hw_backend_api_enhancement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqliteDapper.Demo.ProductMaster;

namespace SqliteDapper.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider productProvider;
        private readonly IProductRepository productRepository;
        private readonly IConfiguration _config;
        private readonly ILogger logger;

        public ProductController(IProductProvider productProvider,
            IProductRepository productRepository, IConfiguration config, ILogger<ProductController> _logger)
        {
            this.productProvider = productProvider;
            this.productRepository = productRepository;
            this._config = config;
            this.logger = _logger;
        }

        public void setConfig() {

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Configuration"))
            //    .AddJsonFile(path: "Settings.json", optional: true, reloadOnChange: true);
            //var config = builder.Build();
            Console.WriteLine("------------------ProductController(Settings.json)--------------------");
            //Console.WriteLine($"AppId = {_config["Player:AppId"]}");
            //Console.WriteLine($"Key = {_config["Player:Key"]}");
            //Console.WriteLine($"Connection String = {_config["ConnectionStrings:DefaultConnectionString"]}");

        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {

            //logger.LogInformation("Start : Getting item details for {ID}");

            //List<string> list = new List<string>();

            //list.Add("A");
            //list.Add("B");

            //logger.LogInformation($"Completed : Item details for  {{{string.Join(", ", list)}}}");

            //setConfig();
            //logger.LogTrace("Loggin Level = 0 (Trace)");
            //logger.LogDebug("Loggin Level = 1 (Debug)");
            //logger.LogInformation("Loggin Level = 2 (Information)");
            //logger.LogWarning("Loggin Level = 3 (Warning )");
            //logger.LogError("Loggin Level = 4 (Error)");
            //logger.LogCritical("Loggin Level = 5 (Critical)");
            return await productProvider.Get();
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task Post([FromBody] dynamic product)
        {
            Console.WriteLine("Standard Numeric Format Specifiers\n");
            await productRepository.Create(product);
        }
    }
}