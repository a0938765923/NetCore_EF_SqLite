
using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqliteDapper.Demo.Database;
using SqliteDapper.Demo.ProductMaster;
using System;

namespace SqliteDapper.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //private IConfigurationRoot GetSettings()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Configuration"))
        //        .AddJsonFile(path: "Settings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}
        public class Settings
        {
            public string[] SupportedCultures { get; set; }
            //public CustomObject CustomObject { get; set; }
        }

        public class AppSetting
        {
            public ConnectionStrings ConnectionStrings { get; set; }

            public Player Player { get; set; }
        }

      
        public class Player
        {
            public string AppId { get; set; }

            public string Key { get; set; }

            public string name { get; set; }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(new DatabaseConfig { Name = Configuration["DatabaseName"] });
            //services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
            services.AddSingleton<IProductProvider, ProductProvider>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.Configure<AppSetting>(this.Configuration);
        }
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IDatabaseBootstrap>().Setup();
        }
    }
}
