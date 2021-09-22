using GreenPipes;
using LCMDB.WSExtractor.ServicioEjecutor.ConsumidoresMQ;
using LCode.NETCore.Base._5._0.Configuracion;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMDB.WSExtractor.ServicioEjecutor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    string ServidorMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Servidor");
                    string MQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Cola");
                    string UsuarioMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Usuario");
                    string ContraseniaMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Contrasenia");
                    var URLMQ = new Uri("rabbitmq://" + ServidorMQ);
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<WSExtractorConsumidor>();
                        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                        {
                            cfg.Host(URLMQ, h =>
                            {
                                h.Username(UsuarioMQ);
                                h.Password(ContraseniaMQ);
                            });
                            cfg.ReceiveEndpoint(MQ, ep =>
                            {
                                ep.PrefetchCount = 16;
                                ep.UseMessageRetry(r => r.Interval(2, 100));
                                ep.ConfigureConsumer<WSExtractorConsumidor>(provider);
                            });
                        }));
                    });
                    services.AddMassTransitHostedService();
                }).UseWindowsService();
    }
}
