﻿// <auto-generated />
using System;
using Enceja.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250414201013_atualizacoes-gerais")]
    partial class atualizacoesgerais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Enceja.Domain.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("class");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("GradeValue")
                        .HasColumnType("INTEGER")
                        .HasColumnName("grade_value");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("student_id");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("grade");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Subject_Class", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("subject_id");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("class_id");

                    b.HasKey("SubjectId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("Subjects_Class");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Teacher_Subject", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("teacher_id");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("subject_id");

                    b.HasKey("TeacherId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("teacher_subject");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Avatar")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Document")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Student", b =>
                {
                    b.HasBaseType("Enceja.Domain.Entities.User");

                    b.Property<int?>("ClassId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("class_id");

                    b.Property<int>("RegistrationNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("registration_number");

                    b.HasIndex("ClassId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Teacher", b =>
                {
                    b.HasBaseType("Enceja.Domain.Entities.User");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Grade", b =>
                {
                    b.HasOne("Enceja.Domain.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Subject_Class", b =>
                {
                    b.HasOne("Enceja.Domain.Entities.Class", "Class")
                        .WithMany("Subjects_Class")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enceja.Domain.Entities.Subject", "Subject")
                        .WithMany("Subjects_Class")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Teacher_Subject", b =>
                {
                    b.HasOne("Enceja.Domain.Entities.Subject", "Subject")
                        .WithMany("Teachers_Subjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enceja.Domain.Entities.Teacher", "Teacher")
                        .WithMany("Teachers_Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Student", b =>
                {
                    b.HasOne("Enceja.Domain.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("Enceja.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Enceja.Domain.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("Enceja.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Enceja.Domain.Entities.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Class", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects_Class");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Subject", b =>
                {
                    b.Navigation("Subjects_Class");

                    b.Navigation("Teachers_Subjects");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("Enceja.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("Teachers_Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
