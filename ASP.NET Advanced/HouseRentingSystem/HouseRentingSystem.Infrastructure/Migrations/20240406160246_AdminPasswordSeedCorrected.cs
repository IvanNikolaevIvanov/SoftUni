using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AdminPasswordSeedCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7d2028d-1948-43d7-a120-8e9738d3f144", "AQAAAAEAACcQAAAAEEzFDq9sT6wf+ch/d8KFlV8aKtSW7V5NctP2hk+QUZ9RcSPSf40EGaA6OA+oPWzCCg==", "95f7679d-3dd5-4df9-9944-29de17904704" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce756b95-b523-49ba-b941-c397aa280044",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca16832f-a664-40f8-89f2-2b0604ac3b8b", "AQAAAAEAACcQAAAAEDLWw7ZtJFc3Zi0Q22IrIdfPgFvcJgr+eV3GGgXILslmkk+gqRVaQU6qBBaAC3bvFw==", "2bb2205b-6cdb-45de-abd6-a04d2e292903" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dc4424b-e2e0-4f4c-bc5c-4d9b9e5e6a20", "AQAAAAEAACcQAAAAENf48nTJw3GbBBBDaxnuQK29/dE3us4vrSPs1l9XLe45eANFtou2Y0VnGFtbljCDdw==", "7eff595f-9ac9-4f63-b5dd-d6e626bbb251" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eab1eb3-53a6-42e9-86f6-818110031657", "AQAAAAEAACcQAAAAEF6JazZQ9YGGDINI/h1OkvJ7MtZUN9nHmS7ggh7BQ+WVXxxKGnB3eqSWPZnP7DL/ZQ==", "e01b788f-e2a1-4eef-a2e1-5712ad0fc0b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce756b95-b523-49ba-b941-c397aa280044",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da333ca8-f2b0-411d-b895-a2b37b14932a", null, "a0d705f3-0f4e-4490-a7ff-978797ae2b8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7c40671-7875-4745-9b6d-1e01c3e28d06", "AQAAAAEAACcQAAAAEGbk62YrVxbDIOdOZsfMOW0MyWtpLNa717ba/sIYG6YRlCmmCCZeVkOgvKkw/49J5g==", "2cadb3ba-17a8-4c81-ba6c-b2013a65a0df" });
        }
    }
}
