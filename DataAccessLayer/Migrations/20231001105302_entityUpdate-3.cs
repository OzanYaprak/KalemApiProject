using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class entityUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 1, 13, 53, 2, 215, DateTimeKind.Local).AddTicks(9778));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 1, 13, 45, 50, 343, DateTimeKind.Local).AddTicks(520));
        }
    }
}
