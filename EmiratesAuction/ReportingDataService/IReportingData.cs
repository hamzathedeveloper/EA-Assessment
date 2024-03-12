using EmiratesAuction.DTO.Request;
using EmiratesAuction.DTO.Response;

namespace EmiratesAuction.ReportingDataService
{
    public interface IReportingData
    {
        Task<List<ReceivableCustomerList>> GetReceivableCustomersList(DateTime asOfDate);
        Task<List<PaymentSettlementReportResponse>> GetPaymentSettlementReport(SettlementReportRequest request);
        Task<List<LogReport>> GetLogReports();
    }
}
