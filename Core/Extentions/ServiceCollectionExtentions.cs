using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicecollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicecollection);
            }
            return ServiceTool.Create(servicecollection);
        }
    }
}
