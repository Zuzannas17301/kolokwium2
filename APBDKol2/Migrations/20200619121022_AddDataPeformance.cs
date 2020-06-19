using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBDKol2.Migrations
{
    public partial class AddDataPeformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistEvent",
                keyColumn: "IdArtist",
                keyValue: 1,
                column: "PerformanceDate",
                value: new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ArtistEvent",
                keyColumn: "IdArtist",
                keyValue: 2,
                column: "PerformanceDate",
                value: new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistEvent",
                keyColumn: "IdArtist",
                keyValue: 1,
                column: "PerformanceDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ArtistEvent",
                keyColumn: "IdArtist",
                keyValue: 2,
                column: "PerformanceDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
