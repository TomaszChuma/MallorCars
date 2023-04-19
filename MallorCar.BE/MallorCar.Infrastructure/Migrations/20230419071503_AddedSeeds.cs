using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MallorCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "ClientEmail", "ClientFirstName", "ClientLastName", "ClientPhoneNumber" },
                values: new object[] { new Guid("d7313719-e5c1-4bd4-b163-f79f13cccfa4"), "tomaszchuma18@gmail.com", "Tomasz", "Chuma", "+48881441146" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { new Guid("4adf23c4-981a-4764-9be5-84794f683de0"), "Alcudia" },
                    { new Guid("ae34c296-26ab-4b14-b5c4-6b952fda024a"), "Palma Airport" },
                    { new Guid("d2c4813f-4cfe-4d79-8f88-9ceec20a9b7a"), "Manacor" },
                    { new Guid("e2858625-1c59-4144-9337-aa5855675027"), "Palma City Center" }
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "ModelId", "ModelAcceleration", "ModelBaseDailyPrice", "ModelName", "ModelNumOfSeats", "ModelPhotoUrl", "ModelRange", "ModelSubName", "ModelTopSpeed" },
                values: new object[,]
                {
                    { new Guid("06b2e583-3225-4ef2-92f7-ff1fb957405b"), 5.7999999999999998, 52m, "3", 5, "3rear", 438, "RW Drive", 225.0 },
                    { new Guid("4a03fd43-6c9f-4fb9-ba53-d09beb52c9fa"), 3.5, 80m, "Y", 5, "yperf", 488, "Performance", 249.0 },
                    { new Guid("6ab8242c-395d-4a55-95c7-ab1acabb26a4"), 3.1000000000000001, 14m, "S", 5, "snormal", 651, null, 240.0 },
                    { new Guid("8a11c1c2-2050-44f5-bfe2-856ce7810e86"), 2.0, 20m, "S", 5, "splaid", 637, "PLaid", 322.0 },
                    { new Guid("a495611d-9a7a-48c0-9776-1f8bd92ba7d9"), 3.7999999999999998, 50m, "X", 7, "xnormal", 560, null, 249.0 },
                    { new Guid("aae9a33e-f407-4d30-abd5-d1fdf9a2cc59"), 4.7999999999999998, 66m, "Y", 7, "ylong", 531, "Long Range", 217.0 },
                    { new Guid("c720d513-4d1a-45e7-9a7a-b6f562768f0b"), 3.1000000000000001, 56m, "3", 5, "3performance", 507, "Performance", 261.0 },
                    { new Guid("d2c6aac2-03ed-4af6-b5c7-34a47ad5b048"), 2.5, 69m, "X", 6, "xplaid", 536, "Plaid", 262.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("d7313719-e5c1-4bd4-b163-f79f13cccfa4"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("4adf23c4-981a-4764-9be5-84794f683de0"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("ae34c296-26ab-4b14-b5c4-6b952fda024a"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d2c4813f-4cfe-4d79-8f88-9ceec20a9b7a"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("e2858625-1c59-4144-9337-aa5855675027"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("06b2e583-3225-4ef2-92f7-ff1fb957405b"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("4a03fd43-6c9f-4fb9-ba53-d09beb52c9fa"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("6ab8242c-395d-4a55-95c7-ab1acabb26a4"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("8a11c1c2-2050-44f5-bfe2-856ce7810e86"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("a495611d-9a7a-48c0-9776-1f8bd92ba7d9"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("aae9a33e-f407-4d30-abd5-d1fdf9a2cc59"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("c720d513-4d1a-45e7-9a7a-b6f562768f0b"));

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "ModelId",
                keyValue: new Guid("d2c6aac2-03ed-4af6-b5c7-34a47ad5b048"));
        }
    }
}
