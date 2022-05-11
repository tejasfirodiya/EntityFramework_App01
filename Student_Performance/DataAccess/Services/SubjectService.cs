using Microsoft.EntityFrameworkCore;
using Student_Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Services;

public class SubjectService
{
    string s = new string('-', 100);
    public void Select()
    {
        using (var Context = new StudentPerformanceContext())
        {
            var subjects = Context.Subjects.Include("course").ToList();

            Console.WriteLine("---------------Subject------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Subject Code | Subject Title           | Course Code | Course Title |");
            Console.WriteLine(s);

            foreach (var subject in subjects)
            {
                Console.WriteLine($"| {subject.Subject_Code,-12} | {subject.Subject_Title,-23} | {subject.course.Course_Code,-11} | {subject.course.Course_Title,-12} |");
            }
            Console.WriteLine(s);
        }
    }

    public void Add()
    {
        Subject subjectObj = new Subject();
        var context = new StudentPerformanceContext();

        subjectObj.SubjectInfo();
        var subject = new Subject
        {
            Subject_Code = subjectObj.Subject_Code,
            Subject_Title = subjectObj.Subject_Title,
            Subject_Description = subjectObj.Subject_Description,
            FK_Course_Id = subjectObj.FK_Course_Id
        };

        context.Subjects.Add(subject);
        context.SaveChanges();

        context.Dispose();
    }

    public void Update()
    {
        Subject subjectObj = new Subject();

        Console.WriteLine("Enter the Subject Code to be updated ");
        var subjectCodeToBeUpdated = Console.ReadLine();

        using var context = new StudentPerformanceContext();

        var subject = context.Subjects.FirstOrDefault(xyz => xyz.Subject_Code == subjectCodeToBeUpdated);

        if (subject == null)
        {
            Console.WriteLine($"Subject Code = {subjectCodeToBeUpdated} not found");
            return;
        }

        subjectObj.SubjectInfo();

        subject.Subject_Code = subjectObj.Subject_Code;
        subject.Subject_Title = subjectObj.Subject_Title;
        subject.Subject_Description = subjectObj.Subject_Description;
        subject.FK_Course_Id = subjectObj.FK_Course_Id;

        context.Subjects.Update(subject);
        context.SaveChanges();
    }

    public void Delete()
    {
        Subject subjectObj = new Subject();

        Console.WriteLine("Enter the Subject Code to be deleted ");
        var subjectCodeToBeUpdated = Console.ReadLine();

        using var context = new StudentPerformanceContext();

        var subject = context.Subjects.FirstOrDefault(xyz => xyz.Subject_Code == subjectCodeToBeUpdated);

        if (subject == null)
        {
            Console.WriteLine($"Subject Code = {subjectCodeToBeUpdated} not found");
            return;
        }

        context.Subjects.Remove(subject);
        context.SaveChanges();

        context.Dispose();
    }
}
