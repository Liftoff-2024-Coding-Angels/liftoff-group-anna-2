using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchCodeCapstone.Migrations
{
    public partial class AddingSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d46d0ff-d3b5-4beb-a544-d7576643d717", "3d46d0ff-d3b5-4beb-a544-d7576643d717", "Admin", "Admin" },
                    { "d980268f-7565-4941-a598-368ab2cea6cb", "d980268f-7565-4941-a598-368ab2cea6cb", "SuperAdmin", "SuperAdmin" },
                    { "ecd445ad - 9d58 - 49ef - 908d - a05ad1e64fa2", "ecd445ad - 9d58 - 49ef - 908d - a05ad1e64fa2", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "408be4a1-f6ab-47e7-a035-4032256da7fa", 0, "5c413326-c211-485b-a5b7-4961bd44e792", "mendozacolonx@gmail.com", false, false, null, "SUPERADMIN", "MENDOZACOLONX@GMAIL.COM", "AQAAAAEAACcQAAAAEDUqo0mh0SMeLcLQUgzD7UVumKdM61lD8yfsKDwXDaiY79F40u5MgW4heJNHxAelaA==", null, false, "e725316d-d38e-48be-a50f-b63216b82878", false, "superAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d46d0ff-d3b5-4beb-a544-d7576643d717", "408be4a1-f6ab-47e7-a035-4032256da7fa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d980268f-7565-4941-a598-368ab2cea6cb", "408be4a1-f6ab-47e7-a035-4032256da7fa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ecd445ad - 9d58 - 49ef - 908d - a05ad1e64fa2", "408be4a1-f6ab-47e7-a035-4032256da7fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d46d0ff-d3b5-4beb-a544-d7576643d717", "408be4a1-f6ab-47e7-a035-4032256da7fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d980268f-7565-4941-a598-368ab2cea6cb", "408be4a1-f6ab-47e7-a035-4032256da7fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ecd445ad - 9d58 - 49ef - 908d - a05ad1e64fa2", "408be4a1-f6ab-47e7-a035-4032256da7fa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d46d0ff-d3b5-4beb-a544-d7576643d717");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d980268f-7565-4941-a598-368ab2cea6cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecd445ad - 9d58 - 49ef - 908d - a05ad1e64fa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408be4a1-f6ab-47e7-a035-4032256da7fa");
        }
    }
}
