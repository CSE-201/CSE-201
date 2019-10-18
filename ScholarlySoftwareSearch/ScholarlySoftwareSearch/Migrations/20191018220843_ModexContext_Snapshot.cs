using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScholarlySoftwareSearch.Migrations
{
    public partial class ModexContext_Snapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClippedSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploaderID = table.Column<string>(nullable: true),
                    SoftwareID = table.Column<string>(nullable: true),
                    ClipDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClippedSoftware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authors = table.Column<string>(nullable: true),
                    UploaderID = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    DownloadURL = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClippedSoftware");

            migrationBuilder.DropTable(
                name: "Software");
        }
    }
}
