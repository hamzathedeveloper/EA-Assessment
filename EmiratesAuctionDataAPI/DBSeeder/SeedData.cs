using EmiratesAuctionDataAPI.Context;
using EmiratesAuctionDataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmiratesAuctionDataAPI.DBSeeder
{
    public class SeedData
    {
        private static readonly Random random = new Random();
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var scopedServiceProvider = scope.ServiceProvider;
            var dbContextOptions = scopedServiceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
            var configuration = scopedServiceProvider.GetRequiredService<IConfiguration>();
            using var context = new AppDbContext(dbContextOptions, configuration);


            // Seed data 
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { Name = "Hamza Hussain" },
                    new Customer { Name = "Ali Khan" },
                    new Customer { Name = "Ahmed Riaz" },
                    new Customer { Name = "Dave Liason" },
                    new Customer { Name = "Kalvim Williams" },
                    new Customer { Name = "Arvind Kumar" }
                );
                context.SaveChanges();
            }

            if (!context.TransactionTypes.Any())
            {
                context.TransactionTypes.AddRange(
                    new TransactionType { TypeName = "Cash Deposits" },
                    new TransactionType { TypeName = "Bank Deposits" },
                    new TransactionType { TypeName = "Services For Customer" },
                    new TransactionType { TypeName = "Invoices " },
                    new TransactionType { TypeName = "Credit Notes" }
                );
                context.SaveChanges();
            }

            if (!context.Services.Any())
            {
                var customers = context.Customers.ToList();
                foreach (var customer in customers)
                {
                    int numberOfServices = random.Next(1, 6); 

                    for (int i = 0; i < numberOfServices; i++)
                    {
                        context.Services.Add(new Service
                        {
                            ServiceDate = GenerateRandomDateTime(),
                            CustomerId = customer.CustomerId
                        });
                    }
                }
                context.SaveChanges();
            }

            if (!context.Invoices.Any())
            {
                var services = context.Services.ToList();
                foreach (var service in services)
                {
                    context.Invoices.Add(new Invoice
                    {
                        Amount = GenerateRandomAmount(), 
                        InvoiceDate = GenerateRandomDateTime(),
                        ServiceId = service.ServiceId
                    });
                }
                context.SaveChanges();
            }

            if (!context.Settlements.Any())
            {
                var invoices = context.Invoices.ToList();
                var transactionTypes = context.TransactionTypes.ToList();
                foreach (var invoice in invoices)
                {
                    context.Settlements.Add(new Settlement
                    {
                        Amount = GenerateRandomAmount(), 
                        SettlementDate = GenerateRandomDateTime(),
                        InvoiceId = invoice.InvoiceId,
                        TransactionTypeId = transactionTypes.First().TransactionTypeId 
                    });
                }
                context.SaveChanges();
            }

        }

        public static decimal GenerateRandomAmount()
        {
            int integerPart = random.Next(1000);
            double fractionalPart = random.NextDouble();
            decimal randomAmount = integerPart + (decimal)fractionalPart;
            return randomAmount;
        }

        public static DateTime GenerateRandomDateTime()
        {
            DateTime currentDate = DateTime.Today;
            DateTime earliestDate = currentDate.AddMonths(-3);

            // Calculate the range in days between the earliest date and today
            int rangeInDays = (currentDate - earliestDate).Days;

            // Generate a random number of days within the range
            int randomDays = random.Next(rangeInDays);

            // Add the random number of days to the earliest date
            DateTime randomDate = earliestDate.AddDays(randomDays);

            // Generate a random time for the DateTime
            randomDate = randomDate.AddHours(random.Next(24))
                                     .AddMinutes(random.Next(60))
                                     .AddSeconds(random.Next(60))
                                     .AddMilliseconds(random.Next(1000));
            return randomDate;
        }
    }
}
