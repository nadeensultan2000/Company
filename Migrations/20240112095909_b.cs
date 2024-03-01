using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Dept_id",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_id",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Dept_id",
                table: "Employees",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Dept_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Dept_id",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_id",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Dept_id",
                table: "Employees",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Dept_id");
        }
    }
}
