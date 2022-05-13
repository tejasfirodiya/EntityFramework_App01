using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Models;

internal class TotalMarks
{
    [Key]
    public int Id { get; set; }

    public int FK_Student_Id { get; set; }
    [ForeignKey("FK_Student_Id")]
    public int  Student_Roll_No { get; set; }
    public string Student_Name { get; set; }
    public Student student22 { get; set; }

    public int Total_Marks { get; set; }

    public int FK_Course_Id { get; set; }
    [ForeignKey("FK_Course_Id")]
    public Course course { get; set; }

}
