﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftUniDatabase_ScaffoldedFromPreviousLection.Models.Configuration;
using SoftUniDatabase_ScaffoldedFromPreviousLection.Models.Example_for_ManyToManyFromLection;

namespace SoftUniDatabase_ScaffoldedFromPreviousLection.Models;

public partial class SoftUniContext : DbContext
{
    public SoftUniContext()
    {
    }

    public SoftUniContext(DbContextOptions<SoftUniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC-VAT\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Address>(entity =>
        //{
        //    entity.HasOne(d => d.Town).WithMany(p => p.Addresses).HasConstraintName("FK_Addresses_Towns");
        //});
        modelBuilder.ApplyConfiguration(new AddressConfiguration());

        #region StudentCourse Exercise from Lection
        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(pk => new { pk.StudentId, pk.CourseId });
            
            /*
            //we have attributes in classes so we dont need to write other thigs for relation which can see below
            entity
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentsCourses)
                .HasForeignKey(sc => sc.StudentId);
            entity
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentsCourses)
                .HasForeignKey(sc => sc.CourseId);
            */
        });


        #endregion

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Address).WithMany(p => p.Employees).HasConstraintName("FK_Employees_Addresses");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Projects).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesProject",
                    r => r.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeesProjects_Projects"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeesProjects_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "ProjectId");
                        j.ToTable("EmployeesProjects");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                        j.IndexerProperty<int>("ProjectId").HasColumnName("ProjectID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
