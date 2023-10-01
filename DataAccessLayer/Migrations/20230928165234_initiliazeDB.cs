using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class initiliazeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Müşteri",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerTcID = table.Column<byte>(type: "tinyint", maxLength: 11, nullable: false),
                    CustomerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Müşteri", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Ürün",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ürün", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDocNumber = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Fatura_Müşteri_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Müşteri",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaSatır",
                columns: table => new
                {
                    SalesInvoiceLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceLineNumber = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaSatır", x => x.SalesInvoiceLineID);
                    table.ForeignKey(
                        name: "FK_FaturaSatır_Fatura_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Fatura",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaSatır_Ürün_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Ürün",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_CustomerID",
                table: "Fatura",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaSatır_InvoiceID",
                table: "FaturaSatır",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaSatır_ProductID",
                table: "FaturaSatır",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturaSatır");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Ürün");

            migrationBuilder.DropTable(
                name: "Müşteri");
        }
    }
}
