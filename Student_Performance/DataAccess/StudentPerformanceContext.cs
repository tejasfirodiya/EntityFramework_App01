using Microsoft.EntityFrameworkCore;
using Student_Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess;

internal class StudentPerformanceContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Marks> Marks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK14\MSSQLSERVER01;Initial Catalog=Student_Performance_Management;Integrated Security=True");
    }
}
