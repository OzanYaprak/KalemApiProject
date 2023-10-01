using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class entityUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Ürün",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 1, 13, 45, 50, 343, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.CreateIndex(
                name: "IX_Ürün_BrandID",
                table: "Ürün",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ürün_Marka_BrandID",
                table: "Ürün",
                column: "BrandID",
                principalTable: "Marka",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ürün_Marka_BrandID",
                table: "Ürün");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropIndex(
                name: "IX_Ürün_BrandID",
                table: "Ürün");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Ürün");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 9, 29, 19, 13, 47, 31, DateTimeKind.Local).AddTicks(6759));
        }
    }
}
