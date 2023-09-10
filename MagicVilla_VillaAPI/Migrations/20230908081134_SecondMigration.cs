using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9407), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9416), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 30,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9421), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 40,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9425), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 50,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9429), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9431) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 60,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9433), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9435) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 70,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9437), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNo",
                keyValue: 80,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9441), new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9212));
        }
    }
}
