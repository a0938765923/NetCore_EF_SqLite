using System;
using System.Collections.Generic;
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

    // GET: api/<ProductController>
    [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            var defaultCulture = _config["SupportedCultures:1"];
            var subProperty1 = _config["CustomObject:Property:SubProperty"];
            var subProperty2 = _config["CustomObject:Property:SubProperty2"];
            var subProperty3 = _config["CustomObject:Property:SubProperty3"];

            Console.WriteLine("this is test1"+ defaultCulture);
            Console.WriteLine("this is test1" + subProperty1);
            Console.WriteLine("this is test2" + subProperty2);
            Console.WriteLine("this is test3" + subProperty3);

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