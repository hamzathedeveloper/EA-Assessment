using Microsoft.Identity.Client;

namespace EmiratesAuctionDataAPI.ResponseDto
{
    public class GetPaymentSettlementReport
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ServiceId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string SettlementType { get; set; }
        public int SettlementId { get; set; }
        public DateTime SettlementDate { get; set; }
    }
}
