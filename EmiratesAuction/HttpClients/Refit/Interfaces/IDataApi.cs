using EmiratesAuction.DTO.Request;
using EmiratesAuction.DTO.Response;
using Refit;

namespace EmiratesAuction.HttpClients.Refit.Interfaces
{
    public interface IDataApi
    {
        [Post("/api/Report/receivable-customers")]
        Task<List<ReceivableCustomerList>> GetReceivableCustomersList([Body] DateTime asOfDate);
        
        [Post("/api/Report/payment-settlement-report")]
        Task<List<PaymentSettlementReportResponse>> GetPaymentSettlementReport([Body] SettlementReportRequest request);
    }
}
