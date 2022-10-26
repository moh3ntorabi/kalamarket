using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogBrand_CatalogType_CatalogTypeId",
                table: "CatalogBrand");

            migrationBuilder.DropIndex(
                name: "IX_CatalogBrand_CatalogTypeId",
                table: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "CatalogTypeId",
                table: "CatalogBrand");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 546, DateTimeKind.Local).AddTicks(3162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 546, DateTimeKind.Local).AddTicks(1485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(6117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(9666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(2880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 543, DateTimeKind.Local).AddTicks(8975),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(4349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 544, DateTimeKind.Local).AddTicks(8078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 544, DateTimeKind.Local).AddTicks(6082),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 544, DateTimeKind.Local).AddTicks(4409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItamComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 543, DateTimeKind.Local).AddTicks(4019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 542, DateTimeKind.Local).AddTicks(8194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 542, DateTimeKind.Local).AddTicks(3105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 542, DateTimeKind.Local).AddTicks(5393),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 535, DateTimeKind.Local).AddTicks(8012),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 419, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.CreateTable(
                name: "CatalogBrandCatalogType",
                columns: table => new
                {
                    CatalogBrandsId = table.Column<int>(type: "int", nullable: false),
                    CatalogTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrandCatalogType", x => new { x.CatalogBrandsId, x.CatalogTypesId });
                    table.ForeignKey(
                        name: "FK_CatalogBrandCatalogType_CatalogBrand_CatalogBrandsId",
                        column: x => x.CatalogBrandsId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogBrandCatalogType_CatalogType_CatalogTypesId",
                        column: x => x.CatalogTypesId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogBrandCatalogType_CatalogTypesId",
                table: "CatalogBrandCatalogType",
                column: "CatalogTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogBrandCatalogType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(8347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 546, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(6340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 546, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(462),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(6117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(3982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(6821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(3912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 545, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(4349),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 543, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(1930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 544, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(49),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 544, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(8103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 544, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItamComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 543, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(9245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 542, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.AddColumn<int>(
                name: "CatalogTypeId",
                table: "CatalogBrand",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(4469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 542, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(6900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 542, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 419, DateTimeKind.Local).AddTicks(2105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 29, 535, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "CatalogTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "CatalogTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "CatalogTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "CatalogTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "CatalogTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "CatalogTypeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogBrand_CatalogTypeId",
                table: "CatalogBrand",
                column: "CatalogTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogBrand_CatalogType_CatalogTypeId",
                table: "CatalogBrand",
                column: "CatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
