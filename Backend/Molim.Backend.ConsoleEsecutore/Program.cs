using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.MSClient;
using Serilog;
using Serilog.Sinks;
using System;

namespace Molim.Backend.ConsoleEsecutore
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configurazioni iniziali

            IConfiguration Config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            var connectionString = Config.GetConnectionString("DefaultConnection");
            var idExecutor = Config.GetSection("IdExecutor").Value;

            var optionsBuilder = new DbContextOptionsBuilder<MolimDb>();
            optionsBuilder.UseMySQL(connectionString);

            var configuration = new API.BusinessLayer.Services.Configuration()
            {

            };

            var serilogLogger = new LoggerConfiguration()
                        .WriteTo.File("console_esecutore_.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger();

            //Create a logger factory
            var loggerFactory = new LoggerFactory().AddSerilog(serilogLogger);

            //Get a logger
            var logger = loggerFactory.CreateLogger<Program>();

            #endregion

            using (MolimDb dbContext = new MolimDb(optionsBuilder.Options, null))
                using (ManagerRichiesteEsecuzioneMS manager = new ManagerRichiesteEsecuzioneMS(dbContext, configuration, null, logger))
                    manager.ExecuteRichieste(idExecutor);


        }
    }
}
