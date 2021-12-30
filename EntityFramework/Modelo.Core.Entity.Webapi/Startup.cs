using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Identity;
using Microsoft.EntityFrameworkCore;
using Modelo.Core.Entity.Webapi.Contexto;

namespace Modelo.Core.Entity.Webapi
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
            services.AddControllers();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Usuario>();

            services.AddDbContext<ProjetosContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("DB_APLICACAO_MODELO")); });
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //No servidor kubernetes com aplicações compartilhadas, a pasta base da rota deve ser informada (nomeappk8s)
            if (!string.IsNullOrEmpty(Configuration["dadosdeploy:nomeappk8s"]))
            {
                app.Use((context, next) =>
                {
                    context.Request.PathBase = "/" + Configuration["dadosdeploy:nomeappk8s"];
                    return next();
                });
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
