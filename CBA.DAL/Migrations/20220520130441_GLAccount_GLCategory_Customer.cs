using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class GLAccount_GLCategory_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GLAccounts_GLCategories_GLCategoryId",
                table: "GLAccounts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "GLCategories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GLCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "GLCategories",
                newName: "CategoryDescription");

            migrationBuilder.RenameColumn(
                name: "GLCategoryId",
                table: "GLAccounts",
                newName: "GlCategoryId");

            migrationBuilder.RenameColumn(
                name: "GLAccountID",
                table: "GLAccounts",
                newName: "GLAccountId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "GLAccounts",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_GLAccounts_GLCategoryId",
                table: "GLAccounts",
                newName: "IX_GLAccounts_GlCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "GLCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CategoryCode",
                table: "GLCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GLCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AccountBalance",
                table: "GLAccounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "AccountCode",
                table: "GLAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "GLAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GLAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AspNetRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewCustomerId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DaysCount = table.Column<int>(type: "int", nullable: true),
                    dailyInterestAccrued = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanInterestRatePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SavingsWithdrawalCount = table.Column<int>(type: "int", nullable: true),
                    CurrentLien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanMonthlyInterestRepay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanMonthlyRepay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanMonthlyPrincipalRepay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanPrincipalRemaining = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TermsOfLoan = table.Column<int>(type: "int", nullable: true),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkedAccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_CustomerAccounts_LinkedAccountID",
                        column: x => x.LinkedAccountID,
                        principalTable: "CustomerAccounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_BranchID",
                table: "CustomerAccounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerID",
                table: "CustomerAccounts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_LinkedAccountID",
                table: "CustomerAccounts",
                column: "LinkedAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccounts_GLCategories_GlCategoryId",
                table: "GLAccounts",
                column: "GlCategoryId",
                principalTable: "GLCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GLAccounts_GLCategories_GlCategoryId",
                table: "GLAccounts");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "GLCategories");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "GLCategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GLCategories");

            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "GLAccounts");

            migrationBuilder.DropColumn(
                name: "AccountCode",
                table: "GLAccounts");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "GLAccounts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GLAccounts");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "GLCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "GLCategories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "GlCategoryId",
                table: "GLAccounts",
                newName: "GLCategoryId");

            migrationBuilder.RenameColumn(
                name: "GLAccountId",
                table: "GLAccounts",
                newName: "GLAccountID");

            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "GLAccounts",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_GLAccounts_GlCategoryId",
                table: "GLAccounts",
                newName: "IX_GLAccounts_GLCategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "GLCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccounts_GLCategories_GLCategoryId",
                table: "GLAccounts",
                column: "GLCategoryId",
                principalTable: "GLCategories",
                principalColumn: "Id");
        }
    }
}
