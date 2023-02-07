using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiManager.Data.Migrations
{
    public partial class RoleUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Taxis_OwnerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Taxis_TaxiId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Taxis");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_TaxiId",
                table: "Orders",
                column: "TaxiId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_OwnerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_TaxiId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "Taxis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxis_IsDeleted",
                table: "Taxis",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Taxis_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "Taxis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Taxis_TaxiId",
                table: "Orders",
                column: "TaxiId",
                principalTable: "Taxis",
                principalColumn: "Id");
        }
    }
}
