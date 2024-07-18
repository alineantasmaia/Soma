using Autofac;
using Master.Rotas.Config;
using Master.Rotas.Dominio.Interface;
using Autofac.Extensions.DependencyInjection;
using Elastic.Apm.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Net.Http.Headers;
using System.Net.Mime;
using Microsoft.Extensions.Options;


namespace Master.Rotas
{
    public class Startup
    {
        public IConfiguration _configuracao;
        public IContainer ApplicationContainer { get; private set; }
        private readonly ContainerBuilder _builder;

        public Startup(IConfiguration config)
        {
            _configuracao = config;
            _builder = new ContainerBuilder();
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagerConfig(_configuracao);
            services.AddVersionedApiExplorer();
            services.AddRepositorioBaseConfig(_configuracao);
            
            services.AddInjecaoDependenciaConfig();

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new ValidationFailedResult(context.ModelState);
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    return result;
                };
            });

            //Now
            services.AddControllers();
            //services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            var corsOrigin = _configuracao.GetSection("Seguranca:Politicas:Cors:OrigemRequisicao").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(_configuracao["Seguranca:Politicas:Cors:Nome"], policy =>
                {
                    policy.WithOrigins(corsOrigin)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.Configure<IConfiguration>(_configuracao);

            services.AddHttpClient("EnvioApi", cliente =>
            {
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });
        }

        public IServiceProvider ConfigureContainer(IServiceCollection services)
        {
            ApplicationContainer = _builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            //app.UseElasticApm(_configuracao);

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpsRedirection();
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseCors(_configuracao["Seguranca:Politicas:Cors:Nome"]);
            }

            app.UseRouting();
            //app.UseSwaggerConfig(provider, _configuracao);

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.MapControllers();
            //app.Run();
        }
    }
}