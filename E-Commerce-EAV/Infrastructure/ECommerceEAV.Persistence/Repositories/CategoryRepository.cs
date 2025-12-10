using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Persistence.Contexts;

namespace ECommerceEAV.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceEAVDbContext context) : base(context)
        {
        }
    }
}







