using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPrice.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_CommodityTypes_CommodityTypeId",
                table: "Commodities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommodityTypes",
                table: "CommodityTypes");

            migrationBuilder.AlterColumn<Guid>(
                name: "CommodityTypeId",
                table: "CommodityTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CommodityTypeId",
                table: "Commodities",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommodityTypes",
                table: "CommodityTypes",
                column: "CommodityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_CommodityTypes_CommodityTypeId",
                table: "Commodities",
                column: "CommodityTypeId",
                principalTable: "CommodityTypes",
                principalColumn: "CommodityTypeId",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("148c9219-668e-416a-8e7c-8a115163a096"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("3fc84562-ead3-4863-99d1-f7ff51b11bf7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("5728ea93-1b88-4717-9525-a42952431f55"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("830824b5-9179-43a5-8cf2-ddf063737f0d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("f03debfa-9b7b-4dea-8f2b-f7fdbd6b6488"));

         

           

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "CommodityId",
                keyValue: new Guid("b9f8d405-2c5e-4d6f-9f7c-4c82a2e6e888"),
                columns: new[] { "CommodityTypeId", "UnitOfMeasureId" },
                values: new object[] { 3001, new Guid("d1b38b33-0268-4b76-97a2-3bdae9d9566a") });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "CommodityId", "CurrentStatusId", "Date", "DateUpdated", "Description", "ExpiryDate", "Grade", "PositionTypeId", "Quantity", "StartDate", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { new Guid("22f075e1-e9ac-4e0b-8f07-b15e81a5be5b"), new Guid("535c51f9-c81f-476c-80c6-b925c6f39a5c"), 5001, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2521), new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2520), null, new DateTime(2025, 12, 8, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2520), null, 6002, 150m, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2519), 51.00m, new Guid("54daf5dd-617d-416b-95d8-e2e658e0f75d") },
                    { new Guid("5ff3cd4e-4ea5-4c2e-a809-aa5cb41ebb5f"), new Guid("88874064-1da6-4880-9fbc-b5486855032d"), 5001, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2514), new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2513), null, new DateTime(2025, 12, 11, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2513), null, 6001, 95m, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2512), 53.00m, new Guid("7d070ac0-f98c-4907-a2b1-da975b5c647d") },
                    { new Guid("6f0c7475-7ba4-479f-823b-93d313571c23"), new Guid("f68e5d14-d4d0-4b4b-a389-6d37415719ae"), 5001, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2492), new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2489), null, new DateTime(2025, 12, 8, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2483), null, 6001, 100m, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2482), 50.00m, new Guid("97922ab8-1edc-4f94-a8c7-dd35729967db") },
                    { new Guid("ba1aa95a-d070-4ce5-9e7e-68897b340ed5"), new Guid("256cf3bf-10b9-4337-a59a-9993ee8d1666"), 5001, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2499), new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2499), null, new DateTime(2025, 12, 6, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2498), null, 6001, 200m, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2497), 51.00m, new Guid("25005896-d162-43bf-bc58-f7153380bfbb") },
                    { new Guid("cbd708ba-8e4d-4b10-93a9-b2f6fbabf6d0"), new Guid("0cfd6c5e-42a5-4708-aed2-d95f93e0d853"), 5001, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2530), new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2529), null, new DateTime(2025, 12, 8, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2529), null, 6002, 250m, new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2528), 51.00m, new Guid("644fa7fc-5ecc-4195-a13a-c6931725dbbd") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a5c70d21-7d22-4f11-a5b0-1f080f16c777"),
                column: "DateRecorded",
                value: new DateTime(2025, 12, 1, 14, 26, 29, 360, DateTimeKind.Utc).AddTicks(2216));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("22f075e1-e9ac-4e0b-8f07-b15e81a5be5b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("5ff3cd4e-4ea5-4c2e-a809-aa5cb41ebb5f"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("6f0c7475-7ba4-479f-823b-93d313571c23"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("ba1aa95a-d070-4ce5-9e7e-68897b340ed5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: new Guid("cbd708ba-8e4d-4b10-93a9-b2f6fbabf6d0"));

            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_CommodityTypes_CommodityTypeId",
                table: "Commodities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommodityTypes",
                table: "CommodityTypes");

            migrationBuilder.AlterColumn<int>(
                name: "CommodityTypeId",
                table: "CommodityTypes",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<int>(
                name: "CommodityTypeId",
                table: "Commodities",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommodityTypes",
                table: "CommodityTypes",
                column: "CommodityTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_CommodityTypes_CommodityTypeId",
                table: "Commodities",
                column: "CommodityTypesId",
                principalTable: "CommodityTypes",
                principalColumn: "CommodityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "CommodityId",
                keyValue: new Guid("b9f8d405-2c5e-4d6f-9f7c-4c82a2e6e888"),
                columns: new[] { "CommodityTypeId", "UnitOfMeasureId" },
                values: new object[] { new Guid("8d92b9f4-1c09-4c91-84aa-16da7084129c"), new Guid("422267a5-1408-456a-a66f-e43e44ae6f10") });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "CommodityId", "CurrentStatusId", "Date", "DateUpdated", "Description", "ExpiryDate", "Grade", "PositionTypeId", "Quantity", "StartDate", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { new Guid("148c9219-668e-416a-8e7c-8a115163a096"), new Guid("ed525345-a29f-41c4-8393-48410cc71224"), 5001, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4465), new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4465), null, new DateTime(2025, 12, 8, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4465), null, 6002, 250m, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4464), 51.00m, new Guid("9f2c648b-dbb8-4422-8ed4-6c6953ff0203") },
                    { new Guid("3fc84562-ead3-4863-99d1-f7ff51b11bf7"), new Guid("b47434b4-f1c2-46f0-8de9-bffaebc6b788"), 5001, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4446), new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4445), null, new DateTime(2025, 12, 6, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4444), null, 6001, 200m, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4444), 51.00m, new Guid("2a746ce8-013e-4793-895e-61c09117a3cc") },
                    { new Guid("5728ea93-1b88-4717-9525-a42952431f55"), new Guid("a53a1e03-af32-4f64-9c1a-cdcb963bc642"), 5001, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4459), new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4458), null, new DateTime(2025, 12, 8, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4458), null, 6002, 150m, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4457), 51.00m, new Guid("f5d56969-8f9b-4d64-b423-ee890c3fb663") },
                    { new Guid("830824b5-9179-43a5-8cf2-ddf063737f0d"), new Guid("4c7c250b-bf56-484a-ba5b-33c1f143539c"), 5001, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4439), new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4437), null, new DateTime(2025, 12, 8, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4431), null, 6001, 100m, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4430), 50.00m, new Guid("8577d9f3-c7d4-4d30-8fa2-438d23fa7fce") },
                    { new Guid("f03debfa-9b7b-4dea-8f2b-f7fdbd6b6488"), new Guid("bc11ba28-debd-41f5-87a0-a83bcf366d32"), 5001, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4454), new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4453), null, new DateTime(2025, 12, 11, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4452), null, 6001, 95m, new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4452), 53.00m, new Guid("34e0dedb-aa52-46cd-b47e-24ca820ca3b6") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a5c70d21-7d22-4f11-a5b0-1f080f16c777"),
                column: "DateRecorded",
                value: new DateTime(2025, 12, 1, 14, 19, 8, 504, DateTimeKind.Utc).AddTicks(4108));
        }
    }
}
