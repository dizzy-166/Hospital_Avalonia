using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Models;

public partial class SheronovContext : DbContext
{
    public SheronovContext()
    {
    }

    public SheronovContext(DbContextOptions<SheronovContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiagnosisTable> DiagnosisTables { get; set; }

    public virtual DbSet<GenderTable> GenderTables { get; set; }

    public virtual DbSet<LoginTable> LoginTables { get; set; }

    public virtual DbSet<RoleTable> RoleTables { get; set; }

    public virtual DbSet<TraitTable> TraitTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    public virtual DbSet<VisitsTable> VisitsTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ngknn.ru;Port=5442;Database=Sheronov;Username=21P;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("C");

        modelBuilder.Entity<DiagnosisTable>(entity =>
        {
            entity.HasKey(e => e.IdDiagnosis).HasName("diagnosis_table_pkey");

            entity.ToTable("diagnosis_table", "HospitalBase");

            entity.Property(e => e.IdDiagnosis).HasColumnName("id_diagnosis");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DiagnosisName)
                .HasMaxLength(255)
                .HasColumnName("diagnosis_name");
        });

        modelBuilder.Entity<GenderTable>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("gender_table_pkey");

            entity.ToTable("gender_table", "HospitalBase");

            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<LoginTable>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("login_table_pkey");

            entity.ToTable("login_table", "HospitalBase");

            entity.HasIndex(e => e.Login, "login_table_login_key").IsUnique();

            entity.Property(e => e.IdLogin).HasColumnName("id_login");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.LoginTables)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("login_table_id_role_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoginTables)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("login_table_id_user_fkey");
        });

        modelBuilder.Entity<RoleTable>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("role_table_pkey");

            entity.ToTable("role_table", "HospitalBase");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        modelBuilder.Entity<TraitTable>(entity =>
        {
            entity.HasKey(e => e.IdTrait).HasName("trait_table_pkey");

            entity.ToTable("trait_table", "HospitalBase");

            entity.Property(e => e.IdTrait).HasColumnName("id_trait");
            entity.Property(e => e.Trait)
                .HasMaxLength(100)
                .HasColumnName("trait");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("user_table_pkey");

            entity.ToTable("user_table", "HospitalBase");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FamilyName)
                .HasMaxLength(100)
                .HasColumnName("family_name");
            entity.Property(e => e.Height)
                .HasPrecision(5, 2)
                .HasColumnName("height");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.Weight)
                .HasPrecision(5, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.UserTables)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("user_table_id_gender_fkey");

            entity.HasMany(d => d.IdTraits).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersTrait",
                    r => r.HasOne<TraitTable>().WithMany()
                        .HasForeignKey("IdTrait")
                        .HasConstraintName("users_traits_id_trait_fkey"),
                    l => l.HasOne<UserTable>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("users_traits_id_user_fkey"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdTrait").HasName("users_traits_pkey");
                        j.ToTable("users_traits", "HospitalBase");
                        j.IndexerProperty<int>("IdUser").HasColumnName("id_user");
                        j.IndexerProperty<int>("IdTrait").HasColumnName("id_trait");
                    });
        });

        modelBuilder.Entity<VisitsTable>(entity =>
        {
            entity.HasKey(e => e.IdVisit).HasName("visits_table_pkey");

            entity.ToTable("visits_table", "HospitalBase");

            entity.Property(e => e.IdVisit).HasColumnName("id_visit");
            entity.Property(e => e.IdDiagnosis).HasColumnName("id_diagnosis");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.VisitDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("visit_date");

            entity.HasOne(d => d.IdDiagnosisNavigation).WithMany(p => p.VisitsTables)
                .HasForeignKey(d => d.IdDiagnosis)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("visits_table_id_diagnosis_fkey");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.VisitsTableIdDoctorNavigations)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("visits_table_id_doctor_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.VisitsTableIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("visits_table_id_user_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
