namespace EmiratesAuction.DTO.Response
{
    public class PaymentSettlementReportResponse
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
