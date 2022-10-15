using BankJoakim.Models.Accounts;
using BankJoakim.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankJoakim.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        private string DbPath { get; }

        public BankContext(IConfiguration configuration)
        {
            DbPath = configuration["AppSettings:BankDbConnectionString"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"{DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.CreatedOn).IsRequired().HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Account>().Property(a => a.AccountName).IsRequired();
            modelBuilder.Entity<Account>().Property(a => a.Iban).IsRequired();
            modelBuilder.Entity<Account>().Property(a => a.Balance).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Account>().Property(a => a.CreatedOn).IsRequired().HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Account>().Property(a => a.CustomerId).IsRequired(); // required?
            modelBuilder.Entity<Account>().HasOne(a => a.Customer)
                                          .WithMany(c => c.Accounts)
                                          .HasForeignKey(a => a.CustomerId)
                                          .HasConstraintName("FK_Customer")
                                          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
