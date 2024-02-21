using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchCodeCapstone.Migrations.ApplicationDb
{
    public partial class Resolvingunresolvedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e39ba54-91e5-4dc2-9fe7-95a237b2f7ca", "AQAAAAEAACcQAAAAEB0MLK306f8JYIP6nWclYOiq+O+7U769wG87NtBPz4LYQ75rj0L2JqB7V2f2RQZxXg==", "7be9808c-2d97-459f-a5b6-8c05cb2082fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04577861-3707-408f-9d00-6f504af52508", "AQAAAAEAACcQAAAAEMfKcaP3LoT5krOPSdF1F79Y/nkB0+PHl+Dn/1yfycfecq/jOv2uJ23W+l41SVWZ6g==", "daa294c9-f8cd-4c76-a191-1e00bff0e798" });
        }
    }
}
