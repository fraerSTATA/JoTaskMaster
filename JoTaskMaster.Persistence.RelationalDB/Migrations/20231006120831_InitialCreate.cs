using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoTaskMaster.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "LifecycleMethods",
                columns: table => new
                {
                    MethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifecycleMethods", x => x.MethodID);
                });

            migrationBuilder.CreateTable(
                name: "Project_files",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", fixedLength: true, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_files", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserCompanyID = table.Column<int>(type: "int", nullable: false),
                    UserRoleID = table.Column<int>(type: "int", nullable: false),
                    RegistryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Company",
                        column: x => x.UserCompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.UserRoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectModelID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserManagerID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_LifecycleMethods",
                        column: x => x.ProjectModelID,
                        principalTable: "LifecycleMethods",
                        principalColumn: "MethodID");
                    table.ForeignKey(
                        name: "FK_Projects_StatusTypes",
                        column: x => x.StatusID,
                        principalTable: "StatusTypes",
                        principalColumn: "StatusID");
                    table.ForeignKey(
                        name: "FK_Projects_Users",
                        column: x => x.UserManagerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectNoteID = table.Column<int>(type: "int", nullable: false),
                    NoteDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NoteMessage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    NoteUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_Notes_Projects",
                        column: x => x.ProjectNoteID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_Notes_Users",
                        column: x => x.NoteUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Project_Users",
                columns: table => new
                {
                    UserProjectID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Users", x => x.UserProjectID);
                    table.ForeignKey(
                        name: "FK_Project_Users_Projects",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_Project_Users_Users",
                        column: x => x.UserProjectID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskID = table.Column<int>(type: "int", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "date", nullable: true),
                    TastEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    TaskManagerID = table.Column<int>(type: "int", nullable: false),
                    TaskDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TaskStatusID = table.Column<int>(type: "int", nullable: false),
                    SubTaskID = table.Column<int>(type: "int", nullable: true),
                    TaskPriorityID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectTasks1",
                        column: x => x.SubTaskID,
                        principalTable: "ProjectTasks",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects1",
                        column: x => x.ProjectTaskID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ProjectTasks_StatusTypes",
                        column: x => x.TaskStatusID,
                        principalTable: "StatusTypes",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "Task_Responses",
                columns: table => new
                {
                    TaskResponse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TaskMassage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Responses", x => x.TaskResponse);
                    table.ForeignKey(
                        name: "FK_Task_Responses_ProjectTasks",
                        column: x => x.TaskID,
                        principalTable: "ProjectTasks",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_Task_Responses_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    TaskUser = table.Column<int>(type: "int", nullable: false),
                    UserTaskID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_UserTasks_ProjectTasks",
                        column: x => x.TaskID,
                        principalTable: "ProjectTasks",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_UserTasks_Users",
                        column: x => x.TaskUser,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteUserID",
                table: "Notes",
                column: "NoteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProjectNoteID",
                table: "Notes",
                column: "ProjectNoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Users_ProjectID",
                table: "Project_Users",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectModelID",
                table: "Projects",
                column: "ProjectModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusID",
                table: "Projects",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserManagerID",
                table: "Projects",
                column: "UserManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectTaskID",
                table: "ProjectTasks",
                column: "ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_SubTaskID",
                table: "ProjectTasks",
                column: "SubTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_TaskStatusID",
                table: "ProjectTasks",
                column: "TaskStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Responses_TaskID",
                table: "Task_Responses",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Responses_UserID",
                table: "Task_Responses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCompanyID",
                table: "Users",
                column: "UserCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleID",
                table: "Users",
                column: "UserRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_TaskUser",
                table: "UserTasks",
                column: "TaskUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Project_files");

            migrationBuilder.DropTable(
                name: "Project_Users");

            migrationBuilder.DropTable(
                name: "Task_Responses");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "LifecycleMethods");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
