using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwaggerProject.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Project",
                type: "int",
                nullable: true);

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
                name: "IX_Project_EmployeeId",
                table: "Project",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_EmployeeId",
                table: "Project",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_EmployeeId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_EmployeeId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Epic",
                keyColumn: "EpicId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId");
        }
    }
}
