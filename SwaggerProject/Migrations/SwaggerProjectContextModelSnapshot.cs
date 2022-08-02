﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwaggerProject.Data;

#nullable disable

namespace SwaggerProject.Migrations
{
    [DbContext(typeof(SwaggerProjectContext))]
    partial class SwaggerProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SwaggerProject.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmployeeName = "James"
                        },
                        new
                        {
                            EmployeeId = 2,
                            EmployeeName = "Kelly"
                        },
                        new
                        {
                            EmployeeId = 3,
                            EmployeeName = "Robin"
                        },
                        new
                        {
                            EmployeeId = 4,
                            EmployeeName = "Carl"
                        },
                        new
                        {
                            EmployeeId = 5,
                            EmployeeName = "Mary"
                        },
                        new
                        {
                            EmployeeId = 6,
                            EmployeeName = "Noel"
                        },
                        new
                        {
                            EmployeeId = 7,
                            EmployeeName = "Jane"
                        },
                        new
                        {
                            EmployeeId = 8,
                            EmployeeName = "Paul"
                        },
                        new
                        {
                            EmployeeId = 9,
                            EmployeeName = "Jessie"
                        });
                });

            modelBuilder.Entity("SwaggerProject.Models.Epic", b =>
                {
                    b.Property<int>("EpicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpicId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EpicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EpicId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Epic");

                    b.HasData(
                        new
                        {
                            EpicId = 1,
                            Description = "First epic.",
                            EpicName = "Epic1",
                            ProjectId = 1
                        },
                        new
                        {
                            EpicId = 2,
                            Description = "Second epic.",
                            EpicName = "Epic2",
                            ProjectId = 1
                        },
                        new
                        {
                            EpicId = 3,
                            Description = "Third epic.",
                            EpicName = "Epic3",
                            ProjectId = 1
                        },
                        new
                        {
                            EpicId = 4,
                            Description = "Fourth epic.",
                            EpicName = "Epic4",
                            ProjectId = 2
                        },
                        new
                        {
                            EpicId = 5,
                            Description = "Fifth epic.",
                            EpicName = "Epic5",
                            ProjectId = 2
                        },
                        new
                        {
                            EpicId = 6,
                            Description = "Sixth epic.",
                            EpicName = "Epic6",
                            ProjectId = 3
                        },
                        new
                        {
                            EpicId = 7,
                            Description = "Seventh epic.",
                            EpicName = "Epic7",
                            ProjectId = 4
                        },
                        new
                        {
                            EpicId = 8,
                            Description = "Eighth epic.",
                            EpicName = "Epic8",
                            ProjectId = 5
                        });
                });

            modelBuilder.Entity("SwaggerProject.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Description = "First project.",
                            EmployeeId = 1,
                            ProjectName = "Project1"
                        },
                        new
                        {
                            ProjectId = 2,
                            Description = "Second project.",
                            EmployeeId = 2,
                            ProjectName = "Project2"
                        },
                        new
                        {
                            ProjectId = 3,
                            Description = "Third project.",
                            EmployeeId = 3,
                            ProjectName = "Project3"
                        },
                        new
                        {
                            ProjectId = 4,
                            Description = "Fourth project.",
                            EmployeeId = 4,
                            ProjectName = "Project4"
                        },
                        new
                        {
                            ProjectId = 5,
                            Description = "Fifth project.",
                            EmployeeId = 5,
                            ProjectName = "Project5"
                        });
                });

            modelBuilder.Entity("SwaggerProject.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EpicId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EpicId");

                    b.ToTable("Task");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            Description = "First task.",
                            EmployeeId = 6,
                            EpicId = 1,
                            TaskName = "Task1"
                        },
                        new
                        {
                            TaskId = 2,
                            Description = "Second task.",
                            EmployeeId = 6,
                            EpicId = 1,
                            TaskName = "Task2"
                        },
                        new
                        {
                            TaskId = 3,
                            Description = "Third task.",
                            EmployeeId = 7,
                            EpicId = 2,
                            TaskName = "Task3"
                        },
                        new
                        {
                            TaskId = 4,
                            Description = "Fourth task.",
                            EmployeeId = 6,
                            EpicId = 3,
                            TaskName = "Task4"
                        },
                        new
                        {
                            TaskId = 5,
                            Description = "Fifth task.",
                            EmployeeId = 8,
                            EpicId = 4,
                            TaskName = "Task5"
                        },
                        new
                        {
                            TaskId = 6,
                            Description = "Sixth task.",
                            EmployeeId = 8,
                            EpicId = 4,
                            TaskName = "Task6"
                        },
                        new
                        {
                            TaskId = 7,
                            Description = "Seventh task.",
                            EmployeeId = 7,
                            EpicId = 4,
                            TaskName = "Task7"
                        },
                        new
                        {
                            TaskId = 8,
                            Description = "Eighth task.",
                            EmployeeId = 9,
                            EpicId = 5,
                            TaskName = "Task8"
                        },
                        new
                        {
                            TaskId = 9,
                            Description = "Ninth task.",
                            EmployeeId = 9,
                            EpicId = 5,
                            TaskName = "Task9"
                        },
                        new
                        {
                            TaskId = 10,
                            Description = "Tenth task.",
                            EmployeeId = 7,
                            EpicId = 6,
                            TaskName = "Task10"
                        },
                        new
                        {
                            TaskId = 11,
                            Description = "Eleventh task.",
                            EpicId = 7,
                            TaskName = "Task11"
                        },
                        new
                        {
                            TaskId = 12,
                            Description = "Twelfth task.",
                            EmployeeId = 6,
                            EpicId = 8,
                            TaskName = "Task12"
                        });
                });

            modelBuilder.Entity("SwaggerProject.Models.Epic", b =>
                {
                    b.HasOne("SwaggerProject.Models.Project", "Project")
                        .WithMany("Epics")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SwaggerProject.Models.Project", b =>
                {
                    b.HasOne("SwaggerProject.Models.Employee", "ProjectManager")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("SwaggerProject.Models.Task", b =>
                {
                    b.HasOne("SwaggerProject.Models.Employee", "Responsible")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SwaggerProject.Models.Epic", "Epic")
                        .WithMany("Tasks")
                        .HasForeignKey("EpicId");

                    b.Navigation("Epic");

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("SwaggerProject.Models.Employee", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("SwaggerProject.Models.Epic", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("SwaggerProject.Models.Project", b =>
                {
                    b.Navigation("Epics");
                });
#pragma warning restore 612, 618
        }
    }
}
