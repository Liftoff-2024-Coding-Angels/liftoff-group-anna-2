using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchCodeCapstone.Migrations.ApplicationDb
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04577861-3707-408f-9d00-6f504af52508", "AQAAAAEAACcQAAAAEMfKcaP3LoT5krOPSdF1F79Y/nkB0+PHl+Dn/1yfycfecq/jOv2uJ23W+l41SVWZ6g==", "daa294c9-f8cd-4c76-a191-1e00bff0e798" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e97cb8-156a-4e22-8f0a-33b6316ad6fd", "AQAAAAEAACcQAAAAECclLkUATR7zmSk8Dk75ze+o41MK/Medjn5tyC4vjRCrYeZDlo1yZE46zI05m6fyow==", "3cc9e364-a24d-4a17-816b-b1a475a14336" });
        }
    }
}
