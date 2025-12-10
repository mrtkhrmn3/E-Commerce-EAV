using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Persistence.Contexts;

namespace ECommerceEAV.Persistence.Repositories
{
    public class ProductAttributeRepository : BaseRepository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(ECommerceEAVDbContext context) : base(context)
        {
        }
    }
}







