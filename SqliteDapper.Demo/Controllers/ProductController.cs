using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using hw_backend_api_enhancement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        public ProductController(IProductProvider productProvider,
            IProductRepository productRepository, IConfiguration config)
        {
            this.productProvider = productProvider;
            this.productRepository = productRepository;
            this._config = config;
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
            //setConfig();
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