using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;

namespace SqliteDapper.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
             BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {

            return WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostContext, config) =>
               {
                   var env = hostContext.HostingEnvironment;
                   config.SetBasePath(Path.Combine(env.ContentRootPath, "Configuration"))
                       .AddJsonFile(path: "settings.json", optional: false, reloadOnChange: true)
                       .AddJsonFile(path: $"settings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                       .AddJsonFile(path: "setting2.json", optional: true, reloadOnChange: true);
                   Console.WriteLine(env.EnvironmentName);
               })
               .UseStartup<Startup>()
               .Build();

        }

    }
}
