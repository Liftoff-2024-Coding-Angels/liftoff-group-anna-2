using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchCodeCapstone.Migrations.WatchListDb
{
    public partial class Updatedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchList_WatchList_WatchListId",
                table: "WatchList");

            migrationBuilder.DropIndex(
                name: "IX_WatchList_WatchListId",
                table: "WatchList");

            migrationBuilder.DropColumn(
                name: "WatchListId",
                table: "WatchList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WatchList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WatchList",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "WatchListId",
                table: "WatchList",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_WatchListId",
                table: "WatchList",
                column: "WatchListId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchList_WatchList_WatchListId",
                table: "WatchList",
                column: "WatchListId",
                principalTable: "WatchList",
                principalColumn: "Id");
        }
    }
}
