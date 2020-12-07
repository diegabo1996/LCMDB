using LCMDB.WorkerServices.ServidoresExtractorApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using NETCore.Base._3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMDB.WorkerServices.ServidorExtractorApi
{
    public class Program
    {
        private static BaseConfiguracion BConf = new BaseConfiguracion();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
                    {
                        services.AddHostedService<Worker>();
                        services.Configure<EventLogSettings>(config =>
                        {
                            config.LogName = "LCMDB.ServidoresExtractor";
                            config.SourceName = "ServidoresExtractor";
                        });
                    })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    }).ConfigureWebHost(config =>
                    {
                        string Puerto = BConf.ObtenerValor("PuertoKestrel");
                        config.UseUrls("http://*:" + Puerto);
                    }).UseWindowsService();
    }
}
