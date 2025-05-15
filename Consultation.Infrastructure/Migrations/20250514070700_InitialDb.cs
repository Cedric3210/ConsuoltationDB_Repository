using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UMID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bulletin",
                columns: table => new
                {
                    BulletinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Notify = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletin", x => x.BulletinID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationNumber);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionLog",
                columns: table => new
                {
                    ActionLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLog", x => x.ActionLogID);
                    table.ForeignKey(
                        name: "FK_ActionLog_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyUMID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EnrolledCourseID = table.Column<int>(type: "int", nullable: false),
                    FacultyScheduleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyID);
                    table.ForeignKey(
                        name: "FK_Faculty_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramID);
                    table.ForeignKey(
                        name: "FK_Program_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultySchedule",
                columns: table => new
                {
                    FacultyScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySchedule", x => x.FacultyScheduleID);
                    table.ForeignKey(
                        name: "FK_FacultySchedule_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ProgramID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentUMID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultationRequest",
                columns: table => new
                {
                    ConsultationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Concern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisapprovedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NotificationNumber = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentID1 = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRequest", x => x.ConsultationID);
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_Faculty_FacultyID1",
                        column: x => x.FacultyID1,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_Notification_NotificationNumber",
                        column: x => x.NotificationNumber,
                        principalTable: "Notification",
                        principalColumn: "NotificationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_Students_StudentID1",
                        column: x => x.StudentID1,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYear",
                columns: table => new
                {
                    SchoolYearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolYearStatus = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYear", x => x.SchoolYearID);
                    table.ForeignKey(
                        name: "FK_SchoolYear_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolYear_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrolledCourse",
                columns: table => new
                {
                    EnrolledCourseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    SchoolYearID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourse", x => x.EnrolledCourseID);
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_SchoolYear_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYear",
                        principalColumn: "SchoolYearID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLog_UsersId",
                table: "ActionLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UsersId",
                table: "Admin",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_FacultyID1",
                table: "ConsultationRequest",
                column: "FacultyID1");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_NotificationNumber",
                table: "ConsultationRequest",
                column: "NotificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_StudentID1",
                table: "ConsultationRequest",
                column: "StudentID1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProgramID",
                table: "Courses",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_CourseID",
                table: "EnrolledCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_FacultyID",
                table: "EnrolledCourse",
                column: "FacultyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_SchoolYearID",
                table: "EnrolledCourse",
                column: "SchoolYearID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_StudentID",
                table: "EnrolledCourse",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_UsersId",
                table: "Faculty",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySchedule_FacultyID",
                table: "FacultySchedule",
                column: "FacultyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Program_DepartmentID",
                table: "Program",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYear_FacultyID",
                table: "SchoolYear",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYear_StudentID",
                table: "SchoolYear",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramID",
                table: "Students",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UsersId",
                table: "Students",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLog");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bulletin");

            migrationBuilder.DropTable(
                name: "ConsultationRequest");

            migrationBuilder.DropTable(
                name: "EnrolledCourse");

            migrationBuilder.DropTable(
                name: "FacultySchedule");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SchoolYear");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
