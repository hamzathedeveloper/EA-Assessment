using EmiratesAuctionDataAPI.Models;

namespace EmiratesAuctionDataAPI.Repository.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetAllServices();

    }
}
