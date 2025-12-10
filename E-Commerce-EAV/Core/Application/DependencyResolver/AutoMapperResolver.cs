using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceEAV.Application.DependencyResolver
{
    public static class AutoMapperResolver
    {
        public static void AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}







