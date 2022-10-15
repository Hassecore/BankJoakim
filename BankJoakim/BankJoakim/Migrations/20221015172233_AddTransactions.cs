using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankJoakim.Migrations
{
    public partial class AddTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ammount = table.Column<double>(type: "float", nullable: false),
                    SendingAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceivingAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingAccount",
                        column: x => x.ReceivingAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_SendingAccountId",
                        column: x => x.SendingAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceivingAccountId",
                table: "Transactions",
                column: "ReceivingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SendingAccountId",
                table: "Transactions",
                column: "SendingAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
