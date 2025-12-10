using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ECommerceEAV.Application.Common.Behaviors;

namespace ECommerceEAV.Application.DependencyResolver
{
    public static class MediatRResolver
    {
        public static void AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}







