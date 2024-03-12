namespace EmiratesAuctionDataAPI.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }

        public List<Settlement> Settlements { get; set; }
    }
}
