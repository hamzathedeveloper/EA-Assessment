namespace EmiratesAuctionDataAPI.Repository.Interfaces
{
    public interface IReportExtraction
    {
        Task ExtractReport(string reportName, DateTime extractionTimestamp, string parameters);
    }
}
