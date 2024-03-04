using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fef5dd0-6189-45f9-9239-671609069b31", "AQAAAAEAACcQAAAAEGpA8J0YgDCw7Nsq3z055LyxGTsqN7irFovPx7iUDtlMfB3GgV3qQDYMJUlwBGZwTQ==", "7db73e6c-1d98-4516-b642-35ab5a0c11b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90712f99-795e-47cc-b0c6-832cd893a866", "AQAAAAEAACcQAAAAEBp8vS4EXPzMY/7sTNd7yNcHAsJTjZKgmJsqxdLDfpZAbHWEikenS696486XcIRnEg==", "5fdaa80a-bad6-40f3-a2d5-a50d923c424e" });
        }
    }
}
