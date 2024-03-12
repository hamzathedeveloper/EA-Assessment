using EmiratesAuctionDataAPI.Context;
using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Repository.Interfaces;
using EmiratesAuctionDataAPI.ResponseDto;

namespace EmiratesAuctionDataAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetReceivableCustomers> GetAllCustomers(DateTime asOfDate)
        {
            return _dbContext.Customers.Select(c => new GetReceivableCustomers
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                NumberOfServices = c.Services.Count(),
                Balance = _dbContext.Invoices
                            .Where(i => i.Service.CustomerId == c.CustomerId && i.InvoiceDate <= asOfDate)
                            .Sum(i => i.Amount)
                          - _dbContext.Settlements
                            .Where(p => p.Invoice.Service.CustomerId == c.CustomerId && p.SettlementDate <= asOfDate)
                            .Sum(p => p.Amount)
            });
        }
    }
}
