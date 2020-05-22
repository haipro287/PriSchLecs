using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriSchLecs.Api.Migrations
{
    public partial class PriSchLecs12053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HashName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Drive = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");
        }
    }
}
