﻿using Lab4_23.Models;
using Lab4_23.Models.Many_to_Many;
using Lab4_23.Models.One_to_Many;
using Lab4_23.Models.One_to_One;
using Microsoft.EntityFrameworkCore;

namespace Lab4_23.Data
{
    public class Lab4Context: DbContext
    {
        // HOMEWORK
        public DbSet<Student> Students { get; set; }    
        public DbSet<Teacher> Teachers { get; set; } // many to many
        public DbSet<StudentTeacherRelation> StudentTeacherRelations { get; set; }
        public DbSet<Locker> Lockers { get; set; } // one to one
        public DbSet<University> Universities { get; set; } // one to many

        // One to Many
        public DbSet<Model1> Models1 { get; set; }
        public DbSet<Model2> Models2 { get; set; }


        // One to One
        public DbSet<Model5> Models5 { get; set; }
        public DbSet<Model6> Models6 { get; set; }

        // Many to Many

        public DbSet<Model3> Models3 { get; set; }
        public DbSet<Model4> Models4 { get; set; }
        public DbSet<ModelsRelation> ModelsRelations { get; set; }
        
        public Lab4Context(DbContextOptions<Lab4Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Homework
            // One to many
            modelBuilder.Entity<Student>()
                .HasOne(m1 => m1.University)
                .WithMany(m2 => m2.Students);

            // One to One
            modelBuilder.Entity<Student>()
                .HasOne(m1 => m1.Locker)
                .WithOne()
                .HasForeignKey<Student>(m1 => m1.LockerId);
            
            // Many to Many
            modelBuilder.Entity<StudentTeacherRelation>()
                .HasKey(ts => new { ts.StudentId, ts.TeacherId });

            modelBuilder.Entity<StudentTeacherRelation>()
                .HasOne(ts => ts.Student)
                .WithMany(m1 => m1.TeacherRelations)
                .HasForeignKey(ts => ts.StudentId);
            
            modelBuilder.Entity<StudentTeacherRelation>()
                .HasOne(ts => ts.Teacher)
                .WithMany(m2 => m2.StudentsRelations)
                .HasForeignKey(ts => ts.TeacherId);
            
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Model1>()
                        .HasMany(m1 => m1.Models2)
                        .WithOne(m2 => m2.Model1);


            //// another option
            //modelBuilder.Entity<Model2>()
            //            .HasOne(m2 => m2.Model1)
            //            .WithMany(m1 => m1.Models2);

            // One to One
            modelBuilder.Entity<Model5>()
                .HasOne(m5 => m5.Model6)
                .WithOne(m6 => m6.Model5)
                .HasForeignKey<Model6>(m6 => m6.Model5Id);

            
            // Many to Many
            modelBuilder.Entity<ModelsRelation>().HasKey(mr => new { mr.Model3Id, mr.Model4Id });

            // One to many for m-m
            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Model3)
                        .WithMany(m3 => m3.ModelsRelations)
                        .HasForeignKey(mr => mr.Model3Id);

            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Model4)
                        .WithMany(m4 => m4.ModelsRelations)
                        .HasForeignKey(mr => mr.Model4Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
