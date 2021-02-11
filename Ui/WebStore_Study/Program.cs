using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace WebStore_Study
{
   public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog((host, log)=>log.ReadFrom.Configuration(host.Configuration).WriteTo.Seq("http://localhost:5341/")
                    //.MinimumLevel.Debug()
                    //.MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    //.Enrich.FromLogContext()
                    //.WriteTo.Console(
                    //    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}]{SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}")
                    //.WriteTo.RollingFile(@".\Log\Serilog.log")
                    //.WriteTo.File(new JsonFormatter(",", true), @".\Log\Serilog.log.json")
                );
    }
}
