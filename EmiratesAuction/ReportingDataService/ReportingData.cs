using EmiratesAuction.DTO.Request;
using EmiratesAuction.DTO.Response;
using EmiratesAuction.HttpClients.Refit.Interfaces;

namespace EmiratesAuction.ReportingDataService
{
    public class ReportingData : IReportingData
    {
        private readonly IDataApi _data;

        public ReportingData(IDataApi data)
        {
            _data = data;
        }
        public async Task<List<ReceivableCustomerList>> GetReceivableCustomersList(DateTime asOfDate)
        {
            try
            {
                return await _data.GetReceivableCustomersList(asOfDate);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<List<PaymentSettlementReportResponse>> GetPaymentSettlementReport(SettlementReportRequest request)
        {
            try
            {
                return await _data.GetPaymentSettlementReport(request);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
