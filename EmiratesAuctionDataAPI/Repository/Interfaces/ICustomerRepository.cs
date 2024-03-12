using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.ResponseDto;

namespace EmiratesAuctionDataAPI.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<GetReceivableCustomers> GetAllCustomers(DateTime asOfDate);
    }
}
