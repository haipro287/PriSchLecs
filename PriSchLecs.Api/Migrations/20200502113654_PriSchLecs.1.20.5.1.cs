using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriSchLecs.Api.Migrations
{
    public partial class PriSchLecs12051 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryLecture",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    LectureId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLecture", x => new { x.CategoryId, x.LectureId });
                    table.ForeignKey(
                        name: "FK_CategoryLecture_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryLecture_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLecture_LectureId",
                table: "CategoryLecture",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "CategoryLecture");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentId",
                table: "Category");
        }
    }
}
