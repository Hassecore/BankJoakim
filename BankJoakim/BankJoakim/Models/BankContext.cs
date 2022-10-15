using BankJoakim.Models.Accounts;
using BankJoakim.Models.Customers;
using BankJoakim.Models.Deposits;
using BankJoakim.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankJoakim.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }

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
            modelBuilder.Entity<Account>().HasOne(a => a.Customer)
                                          .WithMany(c => c.Accounts)
                                          .HasForeignKey(a => a.CustomerId)
                                          .HasConstraintName("FK_Customer")
                                          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deposit>().HasKey(d => d.Id);
            modelBuilder.Entity<Deposit>().Property(d => d.Ammount).IsRequired();
            modelBuilder.Entity<Deposit>().Property(d => d.CreatedOn).IsRequired().HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Deposit>().HasOne(d => d.Account)
                                          .WithMany(a => a.Deposits)
                                          .HasForeignKey(d => d.AccountId)
                                          .HasConstraintName("FK_Account")
                                          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>().ToTable("Transactions").HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>().Property(t => t.Ammount).IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.CreatedOn).IsRequired().HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Transaction>().Property(t => t.SendingAccountId).IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.ReceivingAccountId).IsRequired();
            modelBuilder.Entity<Transaction>().HasOne(t => t.ReceivingAccount)
                                              .WithMany(a => a.Transactions)
                                              .HasForeignKey(t => t.ReceivingAccountId)
                                              .HasConstraintName("FK_ReceivingAccount").IsRequired()
                                              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
