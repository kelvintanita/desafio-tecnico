using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using DbUp;
using DesafioTecnico.Application;
using DesafioTecnico.Infra.Data;
using DesafioTecnico.Infra.Data.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using TactoSistemas.Infrastructure.Data;

namespace DesafioTecnico.Api.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DesafioTecnicoConnectionString");

            services.AddDbContext<DesafioTecnicoDbContext>(config =>
                config.UseSqlServer(connectionString));


            var upgradeEngine = DeployChanges.To
                .SqlDatabase(connectionString, null)
                .WithScriptsEmbeddedInAssembly(typeof(InfrastructureData).Assembly, FiltrarSomenteScripts)
                .LogToConsole()
                .LogToTrace()
                .WithTransactionPerScript()
                .Build();

            if (upgradeEngine.IsUpgradeRequired())
            {
                upgradeEngine.PerformUpgrade();
            }

            ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");

            services.AddMvc(options =>
            {

            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssembly(typeof(AppService).Assembly);
                options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });


            services.AddCors(options =>
            {
                options.AddPolicy("PermissiveCorsPolicy", b => b
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AppService)));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Desafio Tecnico API", Version = "v1" });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "DesafioTecnico.Api.xml");

                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }

                options.CustomSchemaIds(c => c.FullName);
            });


            var builder = new ContainerBuilder();
            builder.Populate(services);
            RegisterDependencies(builder);

            ApplicationContainer = builder.Build();

            //GlobalConfiguration.Configuration.UseAutofacActivator(ApplicationContainer);

            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void RegisterDependencies(ContainerBuilder builder)
        {
            // Parâmetros
            var tactoConnectionString = Configuration.GetConnectionString("DesafioTecnicoConnectionString");
            if (string.IsNullOrWhiteSpace(tactoConnectionString)) throw new Exception("Connection string não configurada (TactoConnectionString).");

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            builder
                .RegisterType<DesafioTecnicoDbContext>()
                .AsSelf()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new AutofacModule());
        }

        private bool FiltrarSomenteScripts(string script)
        {
            return script.Contains("Migrations");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            //app.UseHttpsRedirection();
            //app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Tecnico API");
                options.ConfigureOAuth2("swagger", "", "", "Swagger UI");
            });
            //app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
