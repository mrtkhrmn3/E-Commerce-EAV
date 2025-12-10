using ECommerceEAV.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ECommerceEAV.Persistence.DependencyResolver
{
    public static class DbContextResolver
    {
        public static void AddDbContextServices(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
            services.AddDbContext<ECommerceEAVDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies());
        }
    }
}







