using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Models;
[Table("Student", Schema = "student")]

internal class Student
{
    [Key]
    public int Student_Id { get; set; }
    public int Student_Roll_No { get; set; }
    public string Student_Name { get; set; }
    public string Student_email { get; set; }
    public string Student_Address { get; set; }
    
    public int FK_Course_Id { get; set; }
    [ForeignKey("FK_Course_Id")]
    public Course course { get; set; }

    public void AddStudent()
    {
        Console.Write("Enter Student Roll No : ");
         Student_Roll_No = int.Parse(Console.ReadLine());

        Console.Write("Enter Name to insert : ");
         Student_Name = Console.ReadLine();

        Console.Write("Enter Email to insert : ");
         Student_email = Console.ReadLine();

        Console.Write("Enter Address to insert : ");
         Student_Address = Console.ReadLine();

        Console.Write("Enter Course Id : ");
         FK_Course_Id = int.Parse(Console.ReadLine());
    }
}
