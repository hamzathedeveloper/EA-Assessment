namespace EmiratesAuctionDataAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Service> Services { get; set; }
    }
}
