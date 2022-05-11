using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Models;

[Table("Subject", Schema = "course")]

internal class Subject
{
    [Key]
    public int Subject_Id { get; set; }
    public string Subject_Code { get; set; }
    public string Subject_Title { get; set; }
    public string Subject_Description { get; set; }

    public int FK_Course_Id { get; set; }
    [ForeignKey("FK_Course_Id")]
    public Course course { get; set; }

    public void SubjectInfo()
    {
        Console.Write(" \n Enter Subject Code : >> ");
        Subject_Code = Console.ReadLine();

        Console.Write("\n Enter Subject Title : >> ");
        Subject_Title = Console.ReadLine();

        Console.Write("\n Enter Subject Description : >> ");
        Subject_Description = Console.ReadLine();

        Console.Write(" \n Enter Course Id : >> ");
        FK_Course_Id = int.Parse(Console.ReadLine());
    }

}
