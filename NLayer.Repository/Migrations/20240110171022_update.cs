using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_Produtcs_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Produtcs");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "Kırmızı");

            migrationBuilder.UpdateData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Width" },
                values: new object[] { "Mavi", 500 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 10, 20, 10, 22, 213, DateTimeKind.Local).AddTicks(2790), "Kalem 1", 100m, 20, null },
                    { 2, 1, new DateTime(2024, 1, 10, 20, 10, 22, 213, DateTimeKind.Local).AddTicks(2802), "Kalem 2", 200m, 30, null },
                    { 3, 1, new DateTime(2024, 1, 10, 20, 10, 22, 213, DateTimeKind.Local).AddTicks(2804), "Kalem 3", 600m, 60, null },
                    { 4, 2, new DateTime(2024, 1, 10, 20, 10, 22, 213, DateTimeKind.Local).AddTicks(2805), "Kitap 1", 600m, 60, null },
                    { 5, 2, new DateTime(2024, 1, 10, 20, 10, 22, 213, DateTimeKind.Local).AddTicks(2807), "Kitap 2", 6600m, 320, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Produtcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtcs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "red");

            migrationBuilder.UpdateData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Width" },
                values: new object[] { "ble", 300 });

            migrationBuilder.InsertData(
                table: "Produtcs",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 30, 19, 6, 30, 508, DateTimeKind.Local).AddTicks(2443), "Kalem 1", 100m, 20, null },
                    { 2, 1, new DateTime(2023, 6, 30, 19, 6, 30, 508, DateTimeKind.Local).AddTicks(2457), "Kalem 2", 200m, 30, null },
                    { 3, 1, new DateTime(2023, 6, 30, 19, 6, 30, 508, DateTimeKind.Local).AddTicks(2458), "Kalem 3", 600m, 60, null },
                    { 4, 2, new DateTime(2023, 6, 30, 19, 6, 30, 508, DateTimeKind.Local).AddTicks(2460), "Kitap 1", 600m, 60, null },
                    { 5, 2, new DateTime(2023, 6, 30, 19, 6, 30, 508, DateTimeKind.Local).AddTicks(2461), "Kitap 2", 600m, 60, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtcs_CategoryId",
                table: "Produtcs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_Produtcs_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                principalTable: "Produtcs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
