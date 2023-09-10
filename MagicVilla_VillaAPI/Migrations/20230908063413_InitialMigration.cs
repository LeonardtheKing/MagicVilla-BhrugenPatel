using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    VillaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    SquareFit = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.VillaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillaNumber_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "VillaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "VillaId", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SquareFit", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Good road", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9140), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Good road", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9185), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 50, 2000.0, 5000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Good water", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9189), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 51, 2001.0, 5001, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Good electricity", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9191), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 52, 2002.0, 5002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Good road", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9194), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Good road", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9207), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Good road", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9210), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Good road", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9212), "Serenity at its best", "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load", "Confidence Lounge", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VillaNumber",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate", "VillaId" },
                values: new object[,]
                {
                    { 10, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9407), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9410), 1 },
                    { 20, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9416), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9418), 2 },
                    { 30, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9421), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9422), 3 },
                    { 40, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9425), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9427), 4 },
                    { 50, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9429), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9431), 5 },
                    { 60, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9433), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9435), 6 },
                    { 70, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9437), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9439), 7 },
                    { 80, new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9441), "no special details", new DateTime(2023, 9, 8, 7, 34, 13, 282, DateTimeKind.Local).AddTicks(9443), 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber",
                column: "VillaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
