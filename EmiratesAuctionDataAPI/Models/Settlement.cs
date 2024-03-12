namespace EmiratesAuctionDataAPI.Models
{
    public class Settlement
    {
        public int SettlementId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SettlementDate { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; } 
        public int TransactionTypeId { get; set; }  
        public TransactionType TransactionType { get; set; }

    }
}
