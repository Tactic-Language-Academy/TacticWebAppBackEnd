using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TacticWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScoreModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "LevelType",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Score1",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Score3",
                table: "Scores",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Score2",
                table: "Scores",
                newName: "ScoreValue");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentId",
                table: "Scores",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Students_StudentId",
                table: "Scores",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Students_StudentId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_StudentId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Scores",
                newName: "Score3");

            migrationBuilder.RenameColumn(
                name: "ScoreValue",
                table: "Scores",
                newName: "Score2");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelType",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Score1",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
