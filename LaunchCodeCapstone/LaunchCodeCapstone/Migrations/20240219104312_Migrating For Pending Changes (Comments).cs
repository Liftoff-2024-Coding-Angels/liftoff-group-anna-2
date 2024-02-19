using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchCodeCapstone.Migrations
{
    public partial class MigratingForPendingChangesComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e97cb8-156a-4e22-8f0a-33b6316ad6fd", "AQAAAAEAACcQAAAAECclLkUATR7zmSk8Dk75ze+o41MK/Medjn5tyC4vjRCrYeZDlo1yZE46zI05m6fyow==", "3cc9e364-a24d-4a17-816b-b1a475a14336" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c413326-c211-485b-a5b7-4961bd44e792", "AQAAAAEAACcQAAAAEDUqo0mh0SMeLcLQUgzD7UVumKdM61lD8yfsKDwXDaiY79F40u5MgW4heJNHxAelaA==", "e725316d-d38e-48be-a50f-b63216b82878" });
        }
    }
}
