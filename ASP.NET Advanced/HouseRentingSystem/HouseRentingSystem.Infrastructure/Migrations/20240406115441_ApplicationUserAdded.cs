using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class ApplicationUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId1",
                table: "Houses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AgentId1",
                table: "Houses",
                column: "AgentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Agents_AgentId1",
                table: "Houses",
                column: "AgentId1",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Agents_AgentId1",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_AgentId1",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7763a356-4316-4ed7-9320-cdaa338c8eae", "AQAAAAEAACcQAAAAEMvNdCes6kMSD1CHJEeVR/gsrqjL/2CuBr2fyCU0pykcvJKdzjXXWDgzId91oqxBMQ==", "5d6719b6-5c9d-4ed3-bdf6-e7a163ac1f13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "305899a1-e772-487e-90ab-64bf0df0c87c", "AQAAAAEAACcQAAAAEMqEbNCAbrkFNBMsD1bQU7yY1ZaAeSKQQT6aHcKNXitSFD/kX5XlQTZxiQ/7ij1rUQ==", "a1a88db3-3eb6-4b62-8ce8-0031c0dbc0fb" });
        }
    }
}
