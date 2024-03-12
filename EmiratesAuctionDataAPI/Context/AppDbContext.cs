using EmiratesAuctionDataAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmiratesAuctionDataAPI.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ReportLog> ReportLogs { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .HasKey(s => s.ServiceId);

            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.InvoiceId);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Settlement>()
                .HasKey(p => p.SettlementId);

            modelBuilder.Entity<TransactionType>()
                .HasKey(tt => tt.TransactionTypeId);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Service)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.ServiceId);

            modelBuilder.Entity<Settlement>()
                .HasOne(p => p.Invoice)
                .WithMany(i => i.Settlements)
                .HasForeignKey(p => p.InvoiceId);

            modelBuilder.Entity<Settlement>()
                .HasOne(p => p.TransactionType)
                .WithMany()
                .HasForeignKey(p => p.TransactionTypeId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

    }
}
