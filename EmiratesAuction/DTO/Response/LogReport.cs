namespace EmiratesAuction.DTO.Response
{
    public class LogReport
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public DateTime ExtractionTimestamp { get; set; }
        public string UserId { get; set; }
        public string Parameters { get; set; }
    }
}
