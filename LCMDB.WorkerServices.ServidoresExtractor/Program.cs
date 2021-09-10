using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LCMDB.BD.Contextos.LCMDB;
using LCMDB.WorkerServices.ServidoresExtractor.ModelosInternos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LCMDB.WorkerServices.ServidoresExtractor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CMDBContexto contexto = new CMDBContexto();
            contexto.Database.Migrate();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //IConfiguration configuration = hostContext.Configuration;
                    //Configuracion configuracion = configuration.GetSection("Configuracion").Get<Configuracion>();

                    //services.AddSingleton(configuracion);
                    services.AddHostedService<Worker>();
                    services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
                }).UseWindowsService();
    }
}
