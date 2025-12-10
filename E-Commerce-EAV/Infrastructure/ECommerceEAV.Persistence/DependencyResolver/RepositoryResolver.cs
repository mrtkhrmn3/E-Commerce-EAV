using Microsoft.Extensions.DependencyInjection;
using ECommerceEAV.Persistence.Repositories;
using ECommerceEAV.Contract.RepositoryInterfaces;

namespace ECommerceEAV.Persistence.DependencyResolver
{
    public static class RepositoryResolver
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddScoped<IProductAttributeValueRepository, ProductAttributeValueRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
        }
    }
}







