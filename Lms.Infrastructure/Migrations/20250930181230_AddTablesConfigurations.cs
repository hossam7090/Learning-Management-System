using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DID",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_studentSubjects_SubID",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ins_Subjects",
                table: "ins_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_ins_Subjects_SubId",
                table: "ins_Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departmetSubjects_SubID",
                table: "departmetSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                columns: new[] { "SubID", "StudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ins_Subjects",
                table: "ins_Subjects",
                columns: new[] { "SubId", "InsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects",
                columns: new[] { "SubID", "DID" });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_StudID",
                table: "studentSubjects",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_ins_Subjects_InsId",
                table: "ins_Subjects",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_departmetSubjects_DID",
                table: "departmetSubjects",
                column: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DID",
                table: "students",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DID",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_studentSubjects_StudID",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ins_Subjects",
                table: "ins_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_ins_Subjects_InsId",
                table: "ins_Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departmetSubjects_DID",
                table: "departmetSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                columns: new[] { "StudID", "SubID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ins_Subjects",
                table: "ins_Subjects",
                columns: new[] { "InsId", "SubId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects",
                columns: new[] { "DID", "SubID" });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_SubID",
                table: "studentSubjects",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_ins_Subjects_SubId",
                table: "ins_Subjects",
                column: "SubId");

            migrationBuilder.CreateIndex(
                name: "IX_departmetSubjects_SubID",
                table: "departmetSubjects",
                column: "SubID");

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DID",
                table: "students",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");
        }
    }
}
