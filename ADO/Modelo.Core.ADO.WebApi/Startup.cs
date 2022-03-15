using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Modelo.Core.ADO.Infra;
using Modelo.Core.Domain.Entities;
using Modelo.Core.Domain.Interfaces;
using Modelo.Core.Service.Services;
using System;
using System.IO;
using System.Reflection;

namespace Modelo.Core.ADO.WebApi
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
            services.AddControllersWithViews();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Exemplo .NET Core",
                    Description = "API de exemplo utilizando .NET Core e ADO.NET",
                    Contact = new OpenApiContact
                    {
                        Name = "DTI-CAP",
                        Email = "dticia@fazenda.sp.gov.br",
                        Url = new Uri(@"https://ads.intra.fazenda.sp.gov.br/tfs/ADMIN/Wiki_Arquitetura")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });

            #region Serviços

            services.AddTransient<IBaseService<ProjetoEntity>, BaseService<ProjetoEntity>>();

            #endregion

            #region Repositórios

            services.AddTransient<IBaseRepository<ProjetoEntity>, ProjetoRepository>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Exemplo .NET Core V1");
             });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
