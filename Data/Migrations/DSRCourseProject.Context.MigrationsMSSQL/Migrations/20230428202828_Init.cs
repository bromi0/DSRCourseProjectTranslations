using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSRCourseProject.Context.MigrationsMSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceLanguageId = table.Column<int>(type: "int", nullable: false),
                    TargetLanguageId = table.Column<int>(type: "int", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_translations_languages_SourceLanguageId",
                        column: x => x.SourceLanguageId,
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_translations_languages_TargetLanguageId",
                        column: x => x.TargetLanguageId,
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "request_tags",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TranslationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request_tags", x => new { x.TagsId, x.TranslationsId });
                    table.ForeignKey(
                        name: "FK_request_tags_tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_request_tags_translations_TranslationsId",
                        column: x => x.TranslationsId,
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

            migrationBuilder.CreateIndex(
                name: "IX_languages_Name",
                table: "languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_languages_Uid",
                table: "languages",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_request_tags_TranslationsId",
                table: "request_tags",
                column: "TranslationsId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_Uid",
                table: "tags",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tags_Value",
                table: "tags",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_translations_SourceLanguageId",
                table: "translations",
                column: "SourceLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_translations_TargetLanguageId",
                table: "translations",
                column: "TargetLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_translations_Uid",
                table: "translations",
                column: "Uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "request_tags");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "translations");

            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
