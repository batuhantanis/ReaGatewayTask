using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 913, DateTimeKind.Local).AddTicks(1451)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 917, DateTimeKind.Local).AddTicks(4239))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(8602)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(8972))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 925, DateTimeKind.Local).AddTicks(9153)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 925, DateTimeKind.Local).AddTicks(9594))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerEntity_AddressEntity_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 929, DateTimeKind.Local).AddTicks(2316)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 21, 11, 54, 39, 929, DateTimeKind.Local).AddTicks(2748))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntity_AddressEntity_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderEntity_CustomerEntity_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderEntityProductEntity",
                columns: table => new
                {
                    OrderEntitiesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntityProductEntity", x => new { x.OrderEntitiesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderEntityProductEntity_OrderEntity_OrderEntitiesId",
                        column: x => x.OrderEntitiesId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntityProductEntity_ProductEntity_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AddressEntity",
                columns: new[] { "Id", "AddressLine", "City", "CityCode", "Country", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "1", "Ankara", 6, "Turkey", new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(5974), new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6358) },
                    { 2, "2", "İzmir", 35, "Turkey", new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6728), new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6732) },
                    { 3, "3", "NewYork", 355, "America", new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6735), new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6736) },
                    { 4, "4", "Los Angeles", 365, "America", new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6738), new DateTime(2022, 6, 21, 11, 54, 39, 924, DateTimeKind.Local).AddTicks(6739) }
                });

            migrationBuilder.InsertData(
                table: "ProductEntity",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5791), "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png", "1. Product", new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5799) },
                    { 2, new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5817), "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png", "2. Product", new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5818) },
                    { 3, new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5820), "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png", "3. Product", new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5822) },
                    { 4, new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5823), "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png", "4. Product", new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5824) },
                    { 5, new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5826), "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png", "5. Product", new DateTime(2022, 6, 21, 11, 54, 39, 933, DateTimeKind.Local).AddTicks(5827) }
                });

            migrationBuilder.InsertData(
                table: "CustomerEntity",
                columns: new[] { "Id", "AddressId", "CreatedAt", "Email", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9063), "test@hotmail.com", "Batuhan", new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9079) },
                    { 3, 2, new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9101), "jason@hotmail.com", "Jason", new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9102) },
                    { 2, 3, new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9097), "mehmet@hotmail.com", "Mehmet", new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9099) },
                    { 4, 4, new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9104), "haluk@hotmail.com", "Haluk", new DateTime(2022, 6, 21, 11, 54, 39, 928, DateTimeKind.Local).AddTicks(9105) }
                });

            migrationBuilder.InsertData(
                table: "OrderEntity",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CustomerId", "Price", "Quantity", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5020), 1, 180.0, 1, "Transferred", new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5036) },
                    { 3, 4, new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5062), 3, 800.0, 3, "Success", new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5063) },
                    { 2, 2, new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5058), 2, 5500.0, 2, "NotPaid", new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5060) },
                    { 4, 3, new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5065), 4, 225.0, 4, "WaitingOrder", new DateTime(2022, 6, 21, 11, 54, 39, 932, DateTimeKind.Local).AddTicks(5067) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEntity_AddressId",
                table: "CustomerEntity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_AddressId",
                table: "OrderEntity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_CustomerId",
                table: "OrderEntity",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityProductEntity_ProductsId",
                table: "OrderEntityProductEntity",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityProductEntity");

            migrationBuilder.DropTable(
                name: "OrderEntity");

            migrationBuilder.DropTable(
                name: "ProductEntity");

            migrationBuilder.DropTable(
                name: "CustomerEntity");

            migrationBuilder.DropTable(
                name: "AddressEntity");
        }
    }
}
