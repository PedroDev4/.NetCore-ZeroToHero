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
using MenuRestAPI_Marcoratti.Context;
using MenuRestAPI_Marcoratti.Services;
using Newtonsoft.Json;
using MenuRestAPI_Marcoratti.Filters;
using MenuRestAPI_Marcoratti.Extensions;
using MenuRestAPI_Marcoratti.Logging;
using MenuRestAPI_Marcoratti.Repository;
using MenuRestAPI_Marcoratti.DTOs.Mappings;
using AutoMapper;

namespace MenuRestAPI_Marcoratti
{
    // Classe STARTUP � == app.ts ou server.ts no NODE.JS <3
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
            // string mySqlConnectionStr= Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnectionStr,ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddDbContext<AppDbContext>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Ignorando o Loop Handling na request
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });


            // AddScoped -> Em uma app Asp.Net Core, cada REQUEST instcia um novo "escopo" de serviço separado.
            services.AddScoped<ApiLoggingFilter>();
            services.AddTransient<IMyService, MyService>(); // Em uma app Asp.Net Core, 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
            var mappingConfig = new MapperConfiguration(mappConfig => {
            
                mappConfig.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            // AddSingleton -> Em uma app Asp.Net Core, TODAS request irão possuir a mesmsa request DTO criado.
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MenuRestAPI_Marcoratti", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MenuRestAPI_Marcoratti v1"));
            }

            loggerFactory.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration { 
                LogLevel = LogLevel.Information
            }));

            // Adiciona Middleware de tratamento de exception global
            app.ConfigureExceptionHandler();

            // Adiciona o MIDDLEWARE para redirecionar para https://
            app.UseHttpsRedirection();

            // Adiciona o MIDDLEWARE de roteamento da API
            app.UseRouting();

            // Adiciona o MIDDLEWARE que habilita a autoriza��o
            app.UseAuthorization();

            // Adiciona o MIDDLEWARE que executa o endpoint do request atual
            app.UseEndpoints(endpoints => {
            
                // Adiciona os endpoints para as Actions dos controllers sem especificar rotas
                endpoints.MapControllers();
            });
        }
    }
}
