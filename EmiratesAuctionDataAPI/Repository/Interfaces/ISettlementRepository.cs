using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.ResponseDto;

namespace EmiratesAuctionDataAPI.Repository.Interfaces
{
    public interface ISettlementRepository
    {
        IEnumerable<GetPaymentSettlementReport> GetAllSettlements(DateTime fromDate, DateTime toDate);

    }
}
