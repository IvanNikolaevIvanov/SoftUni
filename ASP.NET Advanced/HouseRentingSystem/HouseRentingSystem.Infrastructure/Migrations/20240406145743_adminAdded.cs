using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class adminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eab1eb3-53a6-42e9-86f6-818110031657", "Guest", "Guestov", "AQAAAAEAACcQAAAAEF6JazZQ9YGGDINI/h1OkvJ7MtZUN9nHmS7ggh7BQ+WVXxxKGnB3eqSWPZnP7DL/ZQ==", "e01b788f-e2a1-4eef-a2e1-5712ad0fc0b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7c40671-7875-4745-9b6d-1e01c3e28d06", "Agent", "Agentov", "AQAAAAEAACcQAAAAEGbk62YrVxbDIOdOZsfMOW0MyWtpLNa717ba/sIYG6YRlCmmCCZeVkOgvKkw/49J5g==", "2cadb3ba-17a8-4c81-ba6c-b2013a65a0df" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce756b95-b523-49ba-b941-c397aa280044", 0, "da333ca8-f2b0-411d-b895-a2b37b14932a", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", null, null, false, "a0d705f3-0f4e-4490-a7ff-978797ae2b8f", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 5, "+359888888887", "ce756b95-b523-49ba-b941-c397aa280044" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce756b95-b523-49ba-b941-c397aa280044");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "184ca632-f71a-4910-b90f-86e1e6af771d", "", "", "AQAAAAEAACcQAAAAENdHqHNkOdJFimJude/80khz+kYpuq7npMIN+soNHPOtkELPv+N7LDiKAHM3NfLilA==", "739fee66-ffe4-4ef4-aa5b-e43ac09b685f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "588251dd-af3d-4caa-b007-7617b73c569b", "", "", "AQAAAAEAACcQAAAAEINpDgiqpaoyMSN/V5UfYh1GesFKFt7QCjoMFcy5t49SOnL82hbT6S3qTowmkdkctg==", "b2172b28-a320-4c81-a9c9-209cc6416ebc" });
        }
    }
}
