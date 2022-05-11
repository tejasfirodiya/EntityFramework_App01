using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Models;
[Table("Student_Marks", Schema = "marks")]
internal class Marks
{
    [Key]
    public int Student_Marks_Id { get; set; }

    public int FK_Student_Id { get; set; }
    [ForeignKey("FK_Student_Id")]
    public Student student { get; set; }

    public int FK_Subject_Id { get; set; }
    [ForeignKey("FK_Subject_Id")]
    public Subject subject { get; set; }

    public int marks { get; set; }

    public void MarksInfo()
    {
        Console.Write("\n Enter Student ID : >> ");
        FK_Student_Id = int.Parse(Console.ReadLine());

        Console.Write("\n Enter Subject ID : >> ");
        FK_Subject_Id = int.Parse(Console.ReadLine());

        Console.Write(" \n Enter Marks : >> ");
        marks = int.Parse(Console.ReadLine());
    }

}
