namespace EmiratesAuctionDataAPI.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public DateTime ServiceDate { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; } 

        public List<Invoice> Invoices { get; set; }
    }
}
