using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Persistence.Contexts;

namespace ECommerceEAV.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceEAVDbContext context) : base(context)
        {
        }
    }
}







