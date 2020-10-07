using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.API.Migrations
{
    public partial class Languages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLanguage_Language_LanguageId",
                table: "ProjectLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLanguage_Projects_ProjectId",
                table: "ProjectLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectLanguage",
                table: "ProjectLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "ProjectLanguage",
                newName: "ProjectLanguages");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLanguage_ProjectId",
                table: "ProjectLanguages",
                newName: "IX_ProjectLanguages_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLanguage_LanguageId",
                table: "ProjectLanguages",
                newName: "IX_ProjectLanguages_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectLanguages",
                table: "ProjectLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLanguages_Languages_LanguageId",
                table: "ProjectLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLanguages_Projects_ProjectId",
                table: "ProjectLanguages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLanguages_Languages_LanguageId",
                table: "ProjectLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLanguages_Projects_ProjectId",
                table: "ProjectLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectLanguages",
                table: "ProjectLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "ProjectLanguages",
                newName: "ProjectLanguage");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLanguages_ProjectId",
                table: "ProjectLanguage",
                newName: "IX_ProjectLanguage_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLanguages_LanguageId",
                table: "ProjectLanguage",
                newName: "IX_ProjectLanguage_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectLanguage",
                table: "ProjectLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLanguage_Language_LanguageId",
                table: "ProjectLanguage",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLanguage_Projects_ProjectId",
                table: "ProjectLanguage",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
