using EmiratesAuctionDataAPI.Models;

namespace EmiratesAuctionDataAPI.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAllInvoices();

    }
}
