using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Epic",
                columns: table => new
                {
                    EpicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epic", x => x.EpicId);
                    table.ForeignKey(
                        name: "FK_Epic_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpicId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Task_Epic_EpicId",
                        column: x => x.EpicId,
                        principalTable: "Epic",
                        principalColumn: "EpicId");
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "EmployeeName" },
                values: new object[,]
                {
                    { 1, "James" },
                    { 2, "Kelly" },
                    { 3, "Robin" },
                    { 4, "Carl" },
                    { 5, "Mary" },
                    { 6, "Noel" },
                    { 7, "Jane" },
                    { 8, "Paul" },
                    { 9, "Jessie" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "EmployeeId", "ProjectName" },
                values: new object[,]
                {
                    { 1, "First project.", 1, "Project1" },
                    { 2, "Second project.", 2, "Project2" },
                    { 3, "Third project.", 3, "Project3" },
                    { 4, "Fourth project.", 4, "Project4" },
                    { 5, "Fifth project.", 5, "Project5" }
                });

            migrationBuilder.InsertData(
                table: "Epic",
                columns: new[] { "EpicId", "Description", "EpicName", "ProjectId" },
                values: new object[,]
                {
                    { 1, "First epic.", "Epic1", 1 },
                    { 2, "Second epic.", "Epic2", 1 },
                    { 3, "Third epic.", "Epic3", 1 },
                    { 4, "Fourth epic.", "Epic4", 2 },
                    { 5, "Fifth epic.", "Epic5", 2 },
                    { 6, "Sixth epic.", "Epic6", 3 },
                    { 7, "Seventh epic.", "Epic7", 4 },
                    { 8, "Eighth epic.", "Epic8", 5 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "Description", "EmployeeId", "EpicId", "TaskName" },
                values: new object[,]
                {
                    { 1, "First task.", 6, 1, "Task1" },
                    { 2, "Second task.", 6, 1, "Task2" },
                    { 3, "Third task.", 7, 2, "Task3" },
                    { 4, "Fourth task.", 6, 3, "Task4" },
                    { 5, "Fifth task.", 8, 4, "Task5" },
                    { 6, "Sixth task.", 8, 4, "Task6" },
                    { 7, "Seventh task.", 7, 4, "Task7" },
                    { 8, "Eighth task.", 9, 5, "Task8" },
                    { 9, "Ninth task.", 9, 5, "Task9" },
                    { 10, "Tenth task.", 7, 6, "Task10" },
                    { 11, "Eleventh task.", null, 7, "Task11" },
                    { 12, "Twelfth task.", 6, 8, "Task12" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Epic_ProjectId",
                table: "Epic",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EmployeeId",
                table: "Project",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeId",
                table: "Task",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EpicId",
                table: "Task",
                column: "EpicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Epic");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
