using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworthInfrastructure.Persistence.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Institution_InstitutionId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Institution",
                table: "Institution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountType",
                table: "AccountType");

            migrationBuilder.RenameTable(
                name: "Institution",
                newName: "Institutions");

            migrationBuilder.RenameTable(
                name: "AccountType",
                newName: "AccountTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Institutions",
                table: "Institutions",
                column: "Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes",
                column: "Value");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Value",
                keyValue: 3,
                column: "Name",
                value: "LIRA");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Value",
                keyValue: 4,
                column: "Name",
                value: "Taxable");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Value",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Institutions_InstitutionId",
                table: "Accounts",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Value",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Institutions_InstitutionId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Institutions",
                table: "Institutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes");

            migrationBuilder.RenameTable(
                name: "Institutions",
                newName: "Institution");

            migrationBuilder.RenameTable(
                name: "AccountTypes",
                newName: "AccountType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Institution",
                table: "Institution",
                column: "Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountType",
                table: "AccountType",
                column: "Value");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "Value",
                keyValue: 3,
                column: "Name",
                value: "Taxable");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "Value",
                keyValue: 4,
                column: "Name",
                value: "LIRA");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Institution_InstitutionId",
                table: "Accounts",
                column: "InstitutionId",
                principalTable: "Institution",
                principalColumn: "Value",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
