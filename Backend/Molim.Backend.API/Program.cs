using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Molim.Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cb = new ConfigurationBuilder()
#if DEBUG
                .AddJsonFile("appsettings.json")
#elif RELEASE
                .AddJsonFile("appsettings.Production.json")
#endif
                .Build();            

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(cb)
                .CreateLogger();

            try
            {
                Log.Information("Application startup");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Application startup error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();                    
                });
    }
}
