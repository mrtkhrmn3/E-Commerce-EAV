using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceEAV.Application.DependencyResolver
{
    public static class FluentValidationResolver
    {
        public static void AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}







