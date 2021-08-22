using Autofac;
using DesafioTecnico.Application;
using DesafioTecnico.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DesafioTecnico.Api
{
    public class AutofacModule :  Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyAppService = Assembly.GetAssembly(typeof(AppService));

            builder.RegisterAssemblyTypes(assemblyAppService)
                .Where(t => t.Name.EndsWith("AppService"))
                .AsImplementedInterfaces();


            var assemblyRepository = Assembly.GetAssembly(typeof(InfrastructureData));

            builder.RegisterAssemblyTypes(assemblyRepository)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
