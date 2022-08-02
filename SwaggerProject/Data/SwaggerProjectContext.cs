using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwaggerProject.Models;
using Task = SwaggerProject.Models.Task;

namespace SwaggerProject.Data
{
    public class SwaggerProjectContext : DbContext
    {
        public SwaggerProjectContext (DbContextOptions<SwaggerProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SwaggerProject.Models.Project> Project { get; set; } = default!;

        public DbSet<SwaggerProject.Models.Epic>? Epic { get; set; }

        public DbSet<SwaggerProject.Models.Task>? Task { get; set; }

        public DbSet<SwaggerProject.Models.Employee>? Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee { EmployeeId = 1, EmployeeName = "James" },
                new Employee { EmployeeId = 2, EmployeeName = "Kelly" },
                new Employee { EmployeeId = 3, EmployeeName = "Robin" },
                new Employee { EmployeeId = 4, EmployeeName = "Carl" },
                new Employee { EmployeeId = 5, EmployeeName = "Mary" },
                new Employee { EmployeeId = 6, EmployeeName = "Noel" },
                new Employee { EmployeeId = 7, EmployeeName = "Jane" },
                new Employee { EmployeeId = 8, EmployeeName = "Paul" },
                new Employee { EmployeeId = 9 , EmployeeName = "Jessie" }

                );

            modelBuilder.Entity<Project>().HasData(

                new Project { ProjectId = 1, ProjectName = "Project1", Description = "First project.", EmployeeId = 1 },
                new Project { ProjectId = 2, ProjectName = "Project2", Description = "Second project.", EmployeeId = 2 },
                new Project { ProjectId = 3, ProjectName = "Project3", Description = "Third project.", EmployeeId = 3 },
                new Project { ProjectId = 4, ProjectName = "Project4", Description = "Fourth project.", EmployeeId = 4 },
                new Project { ProjectId = 5, ProjectName = "Project5", Description = "Fifth project.", EmployeeId = 5 }

                );

            modelBuilder.Entity<Epic>().HasData(

                new Epic { EpicId = 1, EpicName = "Epic1", Description = "First epic.", ProjectId = 1 },
                new Epic { EpicId = 2, EpicName = "Epic2", Description = "Second epic.", ProjectId = 1 },
                new Epic { EpicId = 3, EpicName = "Epic3", Description = "Third epic.", ProjectId = 1 },
                new Epic { EpicId = 4, EpicName = "Epic4", Description = "Fourth epic.", ProjectId = 2 },
                new Epic { EpicId = 5, EpicName = "Epic5", Description = "Fifth epic.", ProjectId = 2 },
                new Epic { EpicId = 6, EpicName = "Epic6", Description = "Sixth epic.", ProjectId = 3 },
                new Epic { EpicId = 7, EpicName = "Epic7", Description = "Seventh epic.", ProjectId = 4 },
                new Epic { EpicId = 8, EpicName = "Epic8", Description = "Eighth epic.", ProjectId = 5 }

                );

            modelBuilder.Entity<Task>().HasData(

                new Task { TaskId = 1, TaskName = "Task1", Description = "First task.", EpicId = 1, EmployeeId = 6 },
                new Task { TaskId = 2, TaskName = "Task2", Description = "Second task.", EpicId = 1, EmployeeId = 6 },
                new Task { TaskId = 3, TaskName = "Task3", Description = "Third task.", EpicId = 2, EmployeeId = 7 },
                new Task { TaskId = 4, TaskName = "Task4", Description = "Fourth task.", EpicId = 3, EmployeeId = 6 },
                new Task { TaskId = 5, TaskName = "Task5", Description = "Fifth task.", EpicId = 4, EmployeeId = 8 },
                new Task { TaskId = 6, TaskName = "Task6", Description = "Sixth task.", EpicId = 4, EmployeeId = 8 },
                new Task { TaskId = 7, TaskName = "Task7", Description = "Seventh task.", EpicId = 4, EmployeeId = 7 },
                new Task { TaskId = 8, TaskName = "Task8", Description = "Eighth task.", EpicId = 5, EmployeeId = 9 },
                new Task { TaskId = 9, TaskName = "Task9", Description = "Ninth task.", EpicId = 5, EmployeeId = 9 },
                new Task { TaskId = 10, TaskName = "Task10", Description = "Tenth task.", EpicId = 6, EmployeeId = 7 },
                new Task { TaskId = 11, TaskName = "Task11", Description = "Eleventh task.", EpicId = 7 },
                new Task { TaskId = 12, TaskName = "Task12", Description = "Twelfth task.", EpicId = 8, EmployeeId = 6 }

                );
        }

    }
}
