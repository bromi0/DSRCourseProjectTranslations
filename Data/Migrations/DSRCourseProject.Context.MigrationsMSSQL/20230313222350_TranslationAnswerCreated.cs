using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSRCourseProject.Context.MigrationsMSSQL.Migrations
{
    /// <inheritdoc />
    public partial class TranslationAnswerCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslationRequestId = table.Column<int>(type: "int", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_answers_translations_TranslationRequestId",
                        column: x => x.TranslationRequestId,
                        principalTable: "translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_TranslationRequestId",
                table: "answers",
                column: "TranslationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_answers_Uid",
                table: "answers",
                column: "Uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");
        }
    }
}
