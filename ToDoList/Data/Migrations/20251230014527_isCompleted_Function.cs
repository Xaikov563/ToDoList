using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Data.Migrations
{
    /// <inheritdoc />
    public partial class isCompleted_Function : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_Completed",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_Completed",
                table: "Tasks");
        }
    }
}
