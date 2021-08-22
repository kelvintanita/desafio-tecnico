using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesafioTecnico.Web
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            var connectionString = Configuration.GetConnectionString("DesafioTecnicoConnectionString");

            services.AddDbContext<DesafioTecnicoDbContext>(config =>
                config.UseSqlServer(connectionString));


            //var upgradeEngine = DeployChanges.To
            //    .SqlDatabase(connectionString, null)
            //    .WithScriptsEmbeddedInAssembly(typeof(InfrastructureData).Assembly, FiltrarSomenteScripts)
            //    .LogToConsole()
            //    .LogToTrace()
            //    .WithTransactionPerScript()
            //    .Build();

            //if (upgradeEngine.IsUpgradeRequired())
            //{
            //    upgradeEngine.PerformUpgrade();
            //}

            ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");

            //services.AddMvc(options =>
            //{

            //}).AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssembly(typeof(AppService).Assembly);
            //    options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            //});

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
        }



        private bool FiltrarSomenteScripts(string script)
        {
            return script.Contains("Migrations");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
