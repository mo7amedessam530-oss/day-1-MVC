using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace day_1_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MgrName { get; set; } = string.Empty;
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }

    
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Address { get; set; } = string.Empty;
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<StuCrsRes> StuCrsReses { get; set; } = new List<StuCrsRes>();
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<StuCrsRes> StuCrsReses { get; set; } = new List<StuCrsRes>();
    }

    public class StuCrsRes
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public decimal Grade { get; set; }
    }

    public class SchoolDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StuCrsRes>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}