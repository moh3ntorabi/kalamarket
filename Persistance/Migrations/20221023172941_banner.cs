using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(8347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 637, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(6340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 637, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(462),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 636, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(3982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 637, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(6821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 636, DateTimeKind.Local).AddTicks(3684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(3912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 636, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(4349),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(1930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(49),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(8103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItamComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 634, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(9245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 634, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(4469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 628, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(6900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 634, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 419, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Banners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Banners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Banners",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Banners");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 637, DateTimeKind.Local).AddTicks(4518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 637, DateTimeKind.Local).AddTicks(2617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 636, DateTimeKind.Local).AddTicks(7189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 637, DateTimeKind.Local).AddTicks(609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 428, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 636, DateTimeKind.Local).AddTicks(3684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 636, DateTimeKind.Local).AddTicks(682),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(1210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(4349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(8626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(6811),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 427, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 635, DateTimeKind.Local).AddTicks(4981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItamComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 634, DateTimeKind.Local).AddTicks(8234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 426, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 634, DateTimeKind.Local).AddTicks(6238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 628, DateTimeKind.Local).AddTicks(985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 12, 20, 634, DateTimeKind.Local).AddTicks(3804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 20, 59, 40, 425, DateTimeKind.Local).AddTicks(6900));
        }
    }
}
