using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworthInfrastructure.src.services.networth.networth.infrastructure.Persistence.Migrations
{
    public partial class AccountTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Holdings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountTypeValue = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountType_AccountTypeValue",
                        column: x => x.AccountTypeValue,
                        principalTable: "AccountType",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { 1, "RRSP" },
                    { 2, "TFSA" },
                    { 4, "LIRA" },
                    { 3, "Taxable" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_AccountId",
                table: "Holdings",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeValue",
                table: "Accounts",
                column: "AccountTypeValue");

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_Accounts_AccountId",
                table: "Holdings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_Accounts_AccountId",
                table: "Holdings");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropIndex(
                name: "IX_Holdings_AccountId",
                table: "Holdings");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Holdings");
        }
    }
}
