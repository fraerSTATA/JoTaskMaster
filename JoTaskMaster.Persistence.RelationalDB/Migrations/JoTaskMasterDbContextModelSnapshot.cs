﻿// <auto-generated />
using System;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JoTaskMaster.Domain.Migrations
{
    [DbContext(typeof(JoTaskMasterDbContext))]
    partial class JoTaskMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompanyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.LifecycleMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MethodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LifecycleMethods");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NoteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NoteMessage")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("NoteUserId")
                        .HasColumnType("int")
                        .HasColumnName("NoteUserID");

                    b.Property<int>("ProjectNoteId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectNoteID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NoteUserId" }, "IX_Notes_NoteUserID");

                    b.HasIndex(new[] { "ProjectNoteId" }, "IX_Notes_ProjectNoteID");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("ProjectModelId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectModelID");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserManagerId")
                        .HasColumnType("int")
                        .HasColumnName("UserManagerID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectModelId" }, "IX_Projects_ProjectModelID");

                    b.HasIndex(new[] { "StatusId" }, "IX_Projects_StatusID");

                    b.HasIndex(new[] { "UserManagerId" }, "IX_Projects_UserManagerID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.ProjectFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FileID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project_files", (string)null);
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.ProjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectTaskId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectTaskID");

                    b.Property<int?>("SubTaskId")
                        .HasColumnType("int")
                        .HasColumnName("SubTaskID");

                    b.Property<DateTime?>("TaskDate")
                        .HasColumnType("date");

                    b.Property<string>("TaskDescription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("TaskManagerId")
                        .HasColumnType("int")
                        .HasColumnName("TaskManagerID");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("int")
                        .HasColumnName("TaskStatusID");

                    b.Property<DateTime?>("TastEndDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectTaskId" }, "IX_ProjectTasks_ProjectTaskID");

                    b.HasIndex(new[] { "SubTaskId" }, "IX_ProjectTasks_SubTaskID");

                    b.HasIndex(new[] { "TaskStatusId" }, "IX_ProjectTasks_TaskStatusID");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.ProjectUser", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("UserProjectID");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProjectId" }, "IX_Project_Users_ProjectID");

                    b.ToTable("Project_Users", (string)null);
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.StatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StatusTypes");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.TaskResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskResponseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskId")
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    b.Property<string>("TaskMassage")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TaskId" }, "IX_Task_Responses_TaskID");

                    b.HasIndex(new[] { "UserId" }, "IX_Task_Responses_UserID");

                    b.ToTable("Task_Responses", (string)null);
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("RegistryDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserCompanyId")
                        .HasColumnType("int")
                        .HasColumnName("UserCompanyID");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int")
                        .HasColumnName("UserRoleID");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex(new[] { "UserCompanyId" }, "IX_Users_UserCompanyID");

                    b.HasIndex(new[] { "UserRoleId" }, "IX_Users_UserRoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectTaskId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectTaskID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserTaskId")
                        .HasColumnType("int")
                        .HasColumnName("UserTaskID");

                    b.HasKey("Id");

                    b.HasIndex("UserTaskId");

                    b.HasIndex(new[] { "ProjectTaskId" }, "IX_UserTasks_TaskUser");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Note", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.User", "NoteUser")
                        .WithMany("Notes")
                        .HasForeignKey("NoteUserId")
                        .IsRequired()
                        .HasConstraintName("FK_Notes_Users");

                    b.HasOne("JoTaskMaster.Domain.Entities.Project", "ProjectNote")
                        .WithMany("Notes")
                        .HasForeignKey("ProjectNoteId")
                        .IsRequired()
                        .HasConstraintName("FK_Notes_Projects");

                    b.Navigation("NoteUser");

                    b.Navigation("ProjectNote");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Project", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.LifecycleMethod", "ProjectModel")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectModelId")
                        .IsRequired()
                        .HasConstraintName("FK_Projects_LifecycleMethods");

                    b.HasOne("JoTaskMaster.Domain.Entities.StatusType", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_Projects_StatusTypes");

                    b.HasOne("JoTaskMaster.Domain.Entities.User", "UserManager")
                        .WithMany("Projects")
                        .HasForeignKey("UserManagerId")
                        .IsRequired()
                        .HasConstraintName("FK_Projects_Users");

                    b.Navigation("ProjectModel");

                    b.Navigation("Status");

                    b.Navigation("UserManager");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.ProjectTask", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.Project", "ProjectTaskNavigation")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectTaskId")
                        .IsRequired()
                        .HasConstraintName("FK_ProjectTasks_Projects1");

                    b.HasOne("JoTaskMaster.Domain.Entities.ProjectTask", "SubTask")
                        .WithMany("InverseSubTask")
                        .HasForeignKey("SubTaskId")
                        .HasConstraintName("FK_ProjectTasks_ProjectTasks1");

                    b.HasOne("JoTaskMaster.Domain.Entities.StatusType", "TaskStatus")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("TaskStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_ProjectTasks_StatusTypes");

                    b.Navigation("ProjectTaskNavigation");

                    b.Navigation("SubTask");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.ProjectUser", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.User", "UserProject")
                        .WithOne("ProjectUser")
                        .HasForeignKey("JoTaskMaster.Domain.Entities.ProjectUser", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_Project_Users_Users");

                    b.HasOne("JoTaskMaster.Domain.Entities.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_Project_Users_Projects");

                    b.Navigation("Project");

                    b.Navigation("UserProject");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.TaskResponse", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.ProjectTask", "Task")
                        .WithMany("TaskResponses")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("FK_Task_Responses_ProjectTasks");

                    b.HasOne("JoTaskMaster.Domain.Entities.User", "User")
                        .WithMany("TaskResponses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Task_Responses_Users");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.User", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.Company", "UserCompany")
                        .WithMany("Users")
                        .HasForeignKey("UserCompanyId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Company");

                    b.HasOne("JoTaskMaster.Domain.Entities.Role", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Roles");

                    b.Navigation("UserCompany");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.UserTask", b =>
                {
                    b.HasOne("JoTaskMaster.Domain.Entities.ProjectTask", "ProjectTask")
                        .WithMany("UserTasks")
                        .HasForeignKey("ProjectTaskId")
                        .IsRequired()
                        .HasConstraintName("FK_UserTasks_ProjectTasks1");

                    b.HasOne("JoTaskMaster.Domain.Entities.User", "UserTaskNavigation")
                        .WithMany("UserTasks")
                        .HasForeignKey("UserTaskId")
                        .IsRequired()
                        .HasConstraintName("FK_UserTasks_Users1");

                    b.Navigation("ProjectTask");

                    b.Navigation("UserTaskNavigation");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.LifecycleMethod", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Project", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("ProjectTasks");

                    b.Navigation("ProjectUsers");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.ProjectTask", b =>
                {
                    b.Navigation("InverseSubTask");

                    b.Navigation("TaskResponses");

                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.StatusType", b =>
                {
                    b.Navigation("ProjectTasks");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("JoTaskMaster.Domain.Entities.User", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("ProjectUser");

                    b.Navigation("Projects");

                    b.Navigation("TaskResponses");

                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
