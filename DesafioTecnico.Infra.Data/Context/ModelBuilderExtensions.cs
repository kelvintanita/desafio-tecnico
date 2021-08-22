using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.Infra.Data.Context
{
	public static class ModelBuilderExtensions
	{
		public static void ApplyMappings(this ModelBuilder modelBuilder, Assembly assembly, string @namespace = null)
		{
            //var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);
            var applyGenericMethod = typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(e => e.Name == "ApplyConfiguration");

            var applicableTypes = assembly
				.GetTypes()
				.Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters);
             
			if (!string.IsNullOrWhiteSpace(@namespace))
			{
				applicableTypes = applicableTypes.Where(type => type.Namespace == @namespace);
			}
             
			foreach (var type in applicableTypes)
			{
				foreach (var iface in type.GetInterfaces())
				{
					if (!iface.IsConstructedGenericType ||
					    iface.GetGenericTypeDefinition() != typeof(IEntityTypeConfiguration<>)) continue;
					var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
					applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
					break;
				}
			}
		}
	}
}
