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
        public IActionResult GetReceivableCustomers([FromBody] DateTime asOfDate)
        {
            var receivableCustomers = _reportService.GetReceivableCustomers(asOfDate);
            return Ok(receivableCustomers);
        }

        [HttpPost("payment-settlement-report")]
        public IActionResult GetPaymentSettlementReport([FromBody] SettlementReportRequest request)
        {
            var settlementReport = _reportService.GetPaymentSettlementReport(request.FromDate, request.ToDate);
            return Ok(settlementReport);
        }
    }
}
