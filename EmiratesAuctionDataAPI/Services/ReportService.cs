using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Repository.Interfaces;
using EmiratesAuctionDataAPI.ResponseDto;
using Microsoft.AspNetCore.Identity;

namespace EmiratesAuctionDataAPI.Services
{
    public class ReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISettlementRepository _settlementRepository;
        private readonly IReportExtraction _reportExtraction;
        

        public ReportService(ICustomerRepository customerRepository, ISettlementRepository settlementRepository, IReportExtraction reportExtraction)
        {
            _customerRepository = customerRepository;
            _settlementRepository = settlementRepository;
            _reportExtraction = reportExtraction;
        }

        public async Task<IEnumerable<GetReceivableCustomers>> GetReceivableCustomers(DateTime asOfDate)
        {
           await _reportExtraction.ExtractReport("ReceivableCustomerList", DateTime.Now, asOfDate.ToString());
            return _customerRepository.GetAllCustomers(asOfDate);
        }

        public async Task<IEnumerable<GetPaymentSettlementReport>> GetPaymentSettlementReport(DateTime fromDate, DateTime toDate)
        {
            await _reportExtraction.ExtractReport("PaymentSettlementReport", DateTime.Now, "fromDate"+ fromDate.ToString() + "toDate"+ toDate.ToString());
            return _settlementRepository.GetAllSettlements(fromDate,toDate);
        }

        public async Task<IEnumerable<ReportLog>> GetReportLogs()
        {
            return _reportExtraction.GetReportLogsTable();   
        }
        
    }
}
