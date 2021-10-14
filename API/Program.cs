using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); //CreateHostBuilder(args) is configured in this step //.Build for initilize your host then run it .
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // Loads app configuration from appsettings.json and appsettings.development.json //adds logging providers // sets enviroment variables (launchSettings file)//
                .ConfigureWebHostDefaults(webBuilder => // ConfigureWebHostDefaults ==> Loads variables prefixed with ASPNETCORE_ // set up Kestrel server // sets up other app (servers and middleware) (launchSettings file)
                {
                    webBuilder.UseStartup<Startup>(); // startup :to startup http requests pipelines and your services for dependancy injection .
                });
    }
}
//Kestrel server : is a crossPlatform web server for asp.net and included by default asp.net templates , also u can use it stand alone 