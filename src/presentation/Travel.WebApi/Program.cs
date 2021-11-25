using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;

namespace Travel.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var name = Assembly.GetExecutingAssembly().GetName();
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Assembly", $"{name.Name}")
                .Enrich.WithProperty("Assembly", $"{name.Version}")
                .WriteTo.SQlite(Environment.CurrentDirectory + @"\Logs\log.db", restrictedToMinimumLevel: LogEventLevel.Information, storeTimestampInUtc: true)
                .WriteTo.File(new CompactJsonFormatter(), Environment.CurrentDirectory + @"\Logs\Log.json", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.Console()
                
                
                .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception)
            {
                throw;
            }


            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
