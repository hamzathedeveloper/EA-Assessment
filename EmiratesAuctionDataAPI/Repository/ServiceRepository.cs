using EmiratesAuctionDataAPI.Context;
using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Repository.Interfaces;

namespace EmiratesAuctionDataAPI.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _dbContext;

        public ServiceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Service> GetAllServices()
        {
            return _dbContext.Services.ToList();
        }
    }
}
