using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriSchLecs.Api.Migrations
{
    public partial class PriSchLecs12055 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LectureFile",
                columns: table => new
                {
                    LectureId = table.Column<int>(nullable: false),
                    FileId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureFile", x => new { x.LectureId, x.FileId });
                    table.ForeignKey(
                        name: "FK_LectureFile_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LectureFile_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureFile_FileId",
                table: "LectureFile",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureFile");
        }
    }
}
