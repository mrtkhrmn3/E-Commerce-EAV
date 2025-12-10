using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Persistence.Contexts;

namespace ECommerceEAV.Persistence.Repositories
{
    public class ProductAttributeValueRepository : BaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(ECommerceEAVDbContext context) : base(context)
        {
        }
    }
}







