using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Migrations
{
    /// <inheritdoc />
    public partial class done : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects_Teachers",
                table: "Subjects_Teachers");

            migrationBuilder.DropColumn(
                name: "Subject_TeacherId",
                table: "Subjects_Teachers");

            migrationBuilder.RenameColumn(
                name: "MarkValue",
                table: "Marks",
                newName: "Value");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Subjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects_Teachers",
                table: "Subjects_Teachers",
                columns: new[] { "SubjectId", "TeacherId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Teachers_TeacherId",
                table: "Subjects_Teachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Subjects_SubjectId",
                table: "Marks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_Subjects_SubjectId",
                table: "Subjects_Teachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_Teachers_TeacherId",
                table: "Subjects_Teachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Subjects_SubjectId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_Subjects_SubjectId",
                table: "Subjects_Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_Teachers_TeacherId",
                table: "Subjects_Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects_Teachers",
                table: "Subjects_Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Teachers_TeacherId",
                table: "Subjects_Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Marks",
                newName: "MarkValue");

            migrationBuilder.AddColumn<int>(
                name: "Subject_TeacherId",
                table: "Subjects_Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects_Teachers",
                table: "Subjects_Teachers",
                column: "Subject_TeacherId");
        }
    }
}
