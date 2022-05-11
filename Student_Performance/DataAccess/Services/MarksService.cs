using Microsoft.EntityFrameworkCore;
using Student_Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Services;

internal class MarksService
{
    string s = new string('-', 100);
    public void Select()
    {
        using (var Context = new StudentPerformanceContext())
        {
            var marks = Context.Marks.Include("student").Include("subject").ToList();

            Console.WriteLine("---------------Marks------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Student Id | Student Name         | Subject Id | Subject Title           | Marks |");
            Console.WriteLine(s);

            foreach (var mark in marks)
            {
                Console.WriteLine($"| {mark.FK_Student_Id,-7} | {mark.student.Student_Name,-20} | {mark.FK_Subject_Id} | {mark.subject.Subject_Title,-23} | {mark.marks,-5} |");
            }
            Console.WriteLine(s);
        }
    }

    public void Add()
    {
        Marks marksObj = new Marks();
        var context = new StudentPerformanceContext();

        marksObj.MarksInfo();
        var marks = new Marks
        {
           FK_Student_Id = marksObj.FK_Student_Id,
           FK_Subject_Id = marksObj.FK_Subject_Id,
           marks = marksObj.marks
        };

        context.Marks.Add(marks);
        context.SaveChanges();

        context.Dispose();
    }

    public void Update()
    {
        Marks marksObj = new Marks();

        Console.WriteLine("Enter the Student Id to be updated ");
        var studentIdText = Console.ReadLine();
        var studentIdToBeUpdated = int.Parse(studentIdText);

        using var context = new StudentPerformanceContext();

        var marksUpdate = context.Marks.FirstOrDefault(xyz => xyz.FK_Student_Id == studentIdToBeUpdated);

        if (marksUpdate == null)
        {
            Console.WriteLine($"Student with Roll No = {studentIdToBeUpdated} not found");
            return;
        }

        marksObj.MarksInfo();
        marksUpdate.FK_Student_Id = marksObj.FK_Student_Id;
        marksUpdate.FK_Subject_Id = marksObj.FK_Subject_Id;
        marksUpdate.marks = marksObj.marks;

        context.Marks.Update(marksUpdate);
        context.SaveChanges();
    }

    public void Delete()
    {
        Marks marksObj = new Marks();

        Console.WriteLine("Enter the Student Roll No to be updated ");
        var studentRollNoText = Console.ReadLine();
        var studentRollNoToBeDeleted = int.Parse(studentRollNoText);

        Console.WriteLine("Enter the Subject Code to be updated ");
        var subjectCodeToBeUpdated = Console.ReadLine();

        using var context = new StudentPerformanceContext();

        var marksDelete = context.Marks.FirstOrDefault(xyz => xyz.student.Student_Roll_No == studentRollNoToBeDeleted && xyz.subject.Subject_Code == subjectCodeToBeUpdated);

        if (marksDelete == null)
        {
            Console.WriteLine($"Student with Roll No = {studentRollNoToBeDeleted} not found");
            return;
        }

        context.Marks.Remove(marksDelete);
        context.SaveChanges();

        context.Dispose();
    }


}
