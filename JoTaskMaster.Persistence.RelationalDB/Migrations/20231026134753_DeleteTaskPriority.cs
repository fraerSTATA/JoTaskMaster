using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoTaskMaster.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTaskPriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskPriorityID",
                table: "ProjectTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskPriorityID",
                table: "ProjectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
