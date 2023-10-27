using System;
using System.Collections.Generic;
using JoTaskMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoTaskMaster.Persistence.RelationalDB;

public partial class JoTaskMasterDbContext : DbContext
{
    public JoTaskMasterDbContext()
    {
    }

    public JoTaskMasterDbContext(DbContextOptions<JoTaskMasterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<LifecycleMethod> LifecycleMethods { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectFile> ProjectFiles { get; set; }

    public virtual DbSet<ProjectTask> ProjectTasks { get; set; }

    public virtual DbSet<ProjectUser> ProjectUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StatusType> StatusTypes { get; set; }

    public virtual DbSet<TaskResponse> TaskResponses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-55KITNB;Database=JoTaskDB;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("CompanyID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
        });

        modelBuilder.Entity<LifecycleMethod>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("MethodID");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasIndex(e => e.NoteUserId, "IX_Notes_NoteUserID");

            entity.HasIndex(e => e.ProjectNoteId, "IX_Notes_ProjectNoteID");

            entity.Property(e => e.Id).HasColumnName("NoteID");
            entity.Property(e => e.NoteDate).HasColumnType("datetime");
            entity.Property(e => e.NoteMessage).IsUnicode(false);
            entity.Property(e => e.NoteUserId).HasColumnName("NoteUserID");
            entity.Property(e => e.ProjectNoteId).HasColumnName("ProjectNoteID");

            entity.HasOne(d => d.NoteUser).WithMany(p => p.Notes)
                .HasForeignKey(d => d.NoteUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notes_Users");

            entity.HasOne(d => d.ProjectNote).WithMany(p => p.Notes)
                .HasForeignKey(d => d.ProjectNoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notes_Projects");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasIndex(e => e.ProjectModelId, "IX_Projects_ProjectModelID");

            entity.HasIndex(e => e.StatusId, "IX_Projects_StatusID");

            entity.HasIndex(e => e.UserManagerId, "IX_Projects_UserManagerID");

            entity.Property(e => e.Id).HasColumnName("ProjectID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ProjectModelId).HasColumnName("ProjectModelID");
            entity.Property(e => e.ProjectName).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UserManagerId).HasColumnName("UserManagerID");

            entity.HasOne(d => d.ProjectModel).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projects_LifecycleMethods");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projects_StatusTypes");

            entity.HasOne(d => d.UserManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.UserManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projects_Users");
        });

        modelBuilder.Entity<ProjectFile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Project_files");

            entity.Property(e => e.Id).HasColumnName("FileID");
        });

        modelBuilder.Entity<ProjectTask>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.ProjectTaskId, "IX_ProjectTasks_ProjectTaskID");

            entity.HasIndex(e => e.SubTaskId, "IX_ProjectTasks_SubTaskID");

            entity.HasIndex(e => e.TaskStatusId, "IX_ProjectTasks_TaskStatusID");

            entity.Property(e => e.Id).HasColumnName("TaskID");
            entity.Property(e => e.ProjectTaskId).HasColumnName("ProjectTaskID");
            entity.Property(e => e.SubTaskId).HasColumnName("SubTaskID");
            entity.Property(e => e.TaskDate).HasColumnType("date");
            entity.Property(e => e.TaskDescription).IsUnicode(false);
            entity.Property(e => e.TaskManagerId).HasColumnName("TaskManagerID");
            entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusID");
            entity.Property(e => e.TastEndDate).HasColumnType("date");

            entity.HasOne(d => d.ProjectTaskNavigation).WithMany(p => p.ProjectTasks)
                .HasForeignKey(d => d.ProjectTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTasks_Projects1");

            entity.HasOne(d => d.SubTask).WithMany(p => p.InverseSubTask)
                .HasForeignKey(d => d.SubTaskId)
                .HasConstraintName("FK_ProjectTasks_ProjectTasks1");

            entity.HasOne(d => d.TaskStatus).WithMany(p => p.ProjectTasks)
                .HasForeignKey(d => d.TaskStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTasks_StatusTypes");
        });

        modelBuilder.Entity<ProjectUser>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Project_Users");

            entity.HasIndex(e => e.ProjectId, "IX_Project_Users_ProjectID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("UserProjectID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectUsers)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Users_Projects");

            entity.HasOne(d => d.UserProject).WithOne(p => p.ProjectUser)
                .HasForeignKey<ProjectUser>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Users_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(30);
        });

        modelBuilder.Entity<StatusType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("StatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaskResponse>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Task_Responses");

            entity.HasIndex(e => e.TaskId, "IX_Task_Responses_TaskID");

            entity.HasIndex(e => e.UserId, "IX_Task_Responses_UserID");

            entity.Property(e => e.Id).HasColumnName("TaskResponseID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TaskMassage).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskResponses)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Responses_ProjectTasks");

            entity.HasOne(d => d.User).WithMany(p => p.TaskResponses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Responses_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.HasIndex(e => e.UserCompanyId, "IX_Users_UserCompanyID");

            entity.HasIndex(e => e.UserRoleId, "IX_Users_UserRoleID");

            entity.Property(e => e.Id).HasColumnName("UserID");
            entity.Property(e => e.Email).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistryDate).HasColumnType("datetime");
            entity.Property(e => e.UserCompanyId).HasColumnName("UserCompanyID");
            entity.Property(e => e.UserName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("(N'')");
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.UserSurname).HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.UserCompany).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Company");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.ProjectTaskId, "IX_UserTasks_TaskUser");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.ProjectTaskId).HasColumnName("ProjectTaskID");
            entity.Property(e => e.UserTaskId).HasColumnName("UserTaskID");

            entity.HasOne(d => d.ProjectTask).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.ProjectTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTasks_ProjectTasks1");

            entity.HasOne(d => d.UserTaskNavigation).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.UserTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTasks_Users1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
