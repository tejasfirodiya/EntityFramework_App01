using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Models;
[Table("Course", Schema = "course")]

internal class Course
{
    [Key]
    public int Course_Id { get; set; }
    public string Course_Code { get; set; }
    public string Course_Title { get; set; }
    public string Course_Description { get; set; }

    public void AddCourse()
    {
        Console.Write("Enter Course Code to insert : ");
        Course_Code = Console.ReadLine();

        Console.Write("Enter Couse Title to insert : ");
        Course_Title = Console.ReadLine();

        Console.Write("Enter Course Description to insert : ");
        Course_Description = Console.ReadLine();
    }
}
