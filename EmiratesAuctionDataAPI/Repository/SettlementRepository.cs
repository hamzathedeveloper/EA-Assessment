using EmiratesAuctionDataAPI.Context;
using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Repository.Interfaces;
using EmiratesAuctionDataAPI.ResponseDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmiratesAuctionDataAPI.Repository
{
    public class SettlementRepository : ISettlementRepository
    {
        private readonly AppDbContext _dbContext;

        public SettlementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetPaymentSettlementReport> GetAllSettlements(DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Settlements
            .Where(p => p.SettlementDate >= fromDate && p.SettlementDate<= toDate)
            .Select(p => new GetPaymentSettlementReport
            {
                CustomerId = p.Invoice.Service.CustomerId,
                CustomerName = p.Invoice.Service.Customer.Name,
                ServiceId = p.Invoice.Service.ServiceId,
                ServiceDate = p.Invoice.Service.ServiceDate,
                SettlementType = p.TransactionType.TypeName,
                SettlementId = p.SettlementId,
                SettlementDate = p.SettlementDate
            });
        }
    }
}
