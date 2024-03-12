using EmiratesAuctionDataAPI.Context;
using EmiratesAuctionDataAPI.Models;
using EmiratesAuctionDataAPI.Repository.Interfaces;

namespace EmiratesAuctionDataAPI.Repository
{
    public class ReportExtraction: IReportExtraction
    {
        private readonly AppDbContext _dbContext;

        public ReportExtraction(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ExtractReport(string reportName, DateTime extractionTimestamp, string parameters)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; // Get system username

            var log = new ReportLog
            {
                ReportName = reportName,
                ExtractionTimestamp = extractionTimestamp,
                UserId = userName,
                Parameters = parameters
            };

            // Add the log to the database and save changes
            _dbContext.ReportLogs.Add(log);
            await _dbContext.SaveChangesAsync();
        }
    }
}
