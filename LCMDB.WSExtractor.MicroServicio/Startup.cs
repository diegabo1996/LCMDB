using LCode.NETCore.Base._5._0.Configuracion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using LCode.NETCore.Base._5._0.Excepciones;

namespace LCMDB.WSExtractor.MicroServicio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string ServidorMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Servidor");
            string UsuarioMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Usuario");
            string ContraseniaMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Contrasenia");

            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host(new Uri("rabbitmq://" + ServidorMQ), h =>
                    {
                        h.Username(UsuarioMQ);
                        h.Password(ContraseniaMQ);
                    });
                }));
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LCMDB.WSExtractor.MicroServicio", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LCMDB.WSExtractor.MicroServicio v1"));
            }

            app.UseHttpsRedirection();
            app.UsarApiCapturadorErrores();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
