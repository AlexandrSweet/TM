using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace TaskManagement_Summer2021
{
    public class Program
    {
        public static void Main(string[] args)
        {
           /* var config = new ConfigurationBuilder()//create serilog configuration
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()//create serilog logger
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                //.WriteTo.Console()
                //.MinimumLevel.Information()
                //.Enrich.FromLogContext()
                //.WriteTo.MSSqlServer();
                //.CreateLogger();
                .CreateBootstrapLogger();*/
            CreateHostBuilder(args).Build().Run();
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, configuration) => configuration
                //.WriteTo.Console()
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)) //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
