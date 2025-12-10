using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Persistence.Contexts;

namespace ECommerceEAV.Persistence.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ECommerceEAVDbContext context) : base(context)
        {
        }
    }
}







