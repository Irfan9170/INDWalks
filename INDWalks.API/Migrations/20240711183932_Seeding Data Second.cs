using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INDWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"),
                column: "Name",
                value: "Mumbai");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                column: "Name",
                value: "Delhi");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                column: "Name",
                value: "Varansi");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                column: "Name",
                value: "West Bengal");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                column: "Name",
                value: "Bangalore");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                column: "Name",
                value: "Lucknow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"),
                column: "Name",
                value: "Bay Of Plenty");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                column: "Name",
                value: "Northland");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                column: "Name",
                value: "Nelson");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                column: "Name",
                value: "Wellington");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                column: "Name",
                value: "Southland");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                column: "Name",
                value: "Auckland");
        }
    }
}
