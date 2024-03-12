using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmiratesAuctionDataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("receivable-customers")]
        public async Task<IActionResult> GetReceivableCustomers([FromBody] DateTime asOfDate)
        {
            var receivableCustomers = await _reportService.GetReceivableCustomers(asOfDate);
            return Ok(receivableCustomers);
        }

        [HttpPost("payment-settlement-report")]
        public async Task<IActionResult> GetPaymentSettlementReport([FromBody] SettlementReportRequest request)
        {
            var settlementReport = await _reportService.GetPaymentSettlementReport(request.FromDate.Value, request.ToDate.Value);
            return Ok(settlementReport);
        }

        [HttpPost("report-logs")]
        public async Task<IActionResult> GetReportsLogs()
        {
            var logsReports = await _reportService.GetReportLogs();
            return Ok(logsReports);
        }
    }
}
