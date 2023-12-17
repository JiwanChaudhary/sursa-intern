using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace third.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPhone = table.Column<int>(type: "int", nullable: false),
                    EmpAge = table.Column<int>(type: "int", nullable: false),
                    EmpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
