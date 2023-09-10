using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4928), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4931) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4934), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 30,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4939), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 40,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4943), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 50,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4947), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4949) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 60,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4951), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 70,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4956), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4957) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 80,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4960), new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 39, 32, 483, DateTimeKind.Local).AddTicks(4716));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6587), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6593), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6595) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 30,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6598), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 40,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6602), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 50,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6607), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6608) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 60,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6611), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6613) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 70,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6615), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6617) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 80,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6619), new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6621) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 9, 11, 34, 150, DateTimeKind.Local).AddTicks(6344));
        }
    }
}
