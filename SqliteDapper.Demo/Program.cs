using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System.IO;
using Microsoft.Extensions.Logging;

namespace SqliteDapper.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLogBuilder.ConfigureNLog("NLog.Config").GetCurrentClassLogger();
            //CreateHostBuilder(args).Build().Run();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {

            return WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostContext, config) =>
               {
                   var env = hostContext.HostingEnvironment;
                   config.SetBasePath(Path.Combine(env.ContentRootPath, "Configuration"))
                       .AddJsonFile(path: "settings.json", optional: false, reloadOnChange: true);
                   //.AddJsonFile(path: $"settings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
               })
               .UseStartup<Startup>()
               .ConfigureLogging(logging =>
                   {
                       logging.ClearProviders();
                       logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                   }
               ).UseNLog()
               .Build();

        }

    }
}
