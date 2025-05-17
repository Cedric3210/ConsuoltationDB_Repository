using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyTypeInConsultationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationRequest_Faculty_FacultyID1",
                table: "ConsultationRequest");

            migrationBuilder.DropIndex(
                name: "IX_ConsultationRequest_FacultyID1",
                table: "ConsultationRequest");

            migrationBuilder.DropColumn(
                name: "FacultyID1",
                table: "ConsultationRequest");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyID",
                table: "ConsultationRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_FacultyID",
                table: "ConsultationRequest",
                column: "FacultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationRequest_Faculty_FacultyID",
                table: "ConsultationRequest",
                column: "FacultyID",
                principalTable: "Faculty",
                principalColumn: "FacultyID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationRequest_Faculty_FacultyID",
                table: "ConsultationRequest");

            migrationBuilder.DropIndex(
                name: "IX_ConsultationRequest_FacultyID",
                table: "ConsultationRequest");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyID",
                table: "ConsultationRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FacultyID1",
                table: "ConsultationRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_FacultyID1",
                table: "ConsultationRequest",
                column: "FacultyID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationRequest_Faculty_FacultyID1",
                table: "ConsultationRequest",
                column: "FacultyID1",
                principalTable: "Faculty",
                principalColumn: "FacultyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
