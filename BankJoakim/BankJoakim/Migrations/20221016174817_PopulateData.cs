using Microsoft.EntityFrameworkCore.Migrations;

namespace BankJoakim.Migrations
{
    public partial class PopulateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Customers(Id, FirstName, LastName) VALUES('CFCF40F0-B371-4065-A053-26DF5B03254B', 'Donald', 'Duck')");
            migrationBuilder.Sql("INSERT INTO Customers(Id, FirstName, LastName) VALUES('9C6422C0-35CF-4382-9837-3F9E39D29AD9', 'Mickey', 'Mouse')");
            migrationBuilder.Sql("INSERT INTO Customers(Id, FirstName, LastName) VALUES('CEA59438-00D6-43E0-A12E-64B4B5CED239', 'Snow', 'White')");
            
            migrationBuilder.Sql("INSERT INTO Accounts(Id, AccountName, Iban, Balance, CustomerId) VALUES(NEWID(), 'DonaldsAccount', 'NL86ABNA1363280856', 0, 'CFCF40F0-B371-4065-A053-26DF5B03254B')");
            migrationBuilder.Sql("INSERT INTO Accounts(Id, AccountName, Iban, Balance, CustomerId) VALUES(NEWID(), 'MickeysAccount', 'NL58ABNA7909262728', 0, '9C6422C0-35CF-4382-9837-3F9E39D29AD9')");
            migrationBuilder.Sql("INSERT INTO Accounts(Id, AccountName, Iban, Balance, CustomerId) VALUES(NEWID(), 'SnowWhitesAccount', 'NL32ABNA4952870715', 0, 'CEA59438-00D6-43E0-A12E-64B4B5CED239')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
