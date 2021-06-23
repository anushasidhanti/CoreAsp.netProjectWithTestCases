using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            String url = String.Empty;
            if(args.Length != 0)
            {
                url = "http://localhost:" + args[0];
            }
            else
            {
                url =  Environment.GetEnvironmentVariable("applicationUrl");
            }
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder().UseStartup<Startup>();
            if(!String.IsNullOrEmpty(url))
            {
                webHostBuilder = webHostBuilder.UseUrls(url);
            }
            return webHostBuilder;
        }
    }
}
