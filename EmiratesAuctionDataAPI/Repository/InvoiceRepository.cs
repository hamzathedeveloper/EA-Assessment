using EmiratesAuctionDataAPI.Context;
using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Repository.Interfaces;

namespace EmiratesAuctionDataAPI.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _dbContext;

        public InvoiceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Invoice> GetAllInvoices()
        {
            return _dbContext.Invoices.ToList();
        }
    }
}
