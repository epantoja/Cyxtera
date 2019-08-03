using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var logRepository = log4net.LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());

            //log4net configuraiton for consoleappendar - no config gile needed
            //log4net.Config.BasicConfigurator.Configure(logRepository);

            //Load configuration from log4net.config file
            log4net.Config.XmlConfigurator.Configure(logRepository,
                                                     new System.IO.FileInfo("log4net.config"));   
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
