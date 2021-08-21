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
            //var defaultCulture = _config["SupportedCultures:1"];
            //var subProperty1 = _config["CustomObject:Property:SubProperty1"];
            //var subProperty2 = _config["CustomObject:Property:SubProperty2"];
            //var subProperty3 = _config["CustomObject:Property:SubProperty3"];

            //Console.WriteLine(defaultCulture + "\n");
            //Console.WriteLine(subProperty1 + "\n");
            //Console.WriteLine(subProperty2);
            //Console.WriteLine(subProperty3);
        }

        public void setConfig() {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Configuration"))
                .AddJsonFile(path: "Settings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            Console.WriteLine("------------------ProductController(Settings.json)--------------------");
            Console.WriteLine($"AppId = {config["Player:AppId"]}");
            Console.WriteLine($"Key = {config["Player:Key"]}");
            Console.WriteLine($"Connection String = {config["ConnectionStrings:DefaultConnectionString"]}");

        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            setConfig();
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