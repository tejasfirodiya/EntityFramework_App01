using Student_Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Services;

internal class CourseService
{
    string s = new string('-', 65);

    public void Select()
    {
        using (var Context = new StudentPerformanceContext())
        {
            var courses = Context.Courses.ToList();

            Console.WriteLine("---------------Course------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Course Id | Course Code | Course Title | Course Description |");
            Console.WriteLine(s);

            foreach (var course in courses)
            {
                Console.WriteLine($"| {course.Course_Id,-9} | {course.Course_Code,-11} | {course.Course_Title,-12} | {course.Course_Description,-18} |");
            }
            Console.WriteLine(s);
        }
    }

    public void Add()
    {
        Course courseObj = new Course();

        var context = new StudentPerformanceContext();

        courseObj.AddCourse();

        var course = new Course
        {
            Course_Code = courseObj.Course_Code,
            Course_Title = courseObj.Course_Title,
            Course_Description = courseObj.Course_Description
        };

        context.Courses.Add(course);
        context.SaveChanges();

        context.Dispose();
    }

    public void Update()
    {
        Course courseObj = new Course();

        Console.WriteLine("Enter the Course Id to be updated ");
        var courseIdText = Console.ReadLine();
        var courseIdToBeUpdated = int.Parse(courseIdText);

        using var context = new StudentPerformanceContext();

        var course = context.Courses.FirstOrDefault(xyz => xyz.Course_Id == courseIdToBeUpdated);

        if (course == null)
        {
            Console.WriteLine($"Course with id = {courseIdToBeUpdated} not found");
            return;
        }

        courseObj.AddCourse();

        course.Course_Code = courseObj.Course_Code;
        course.Course_Title = courseObj.Course_Title;
        course.Course_Description = courseObj.Course_Description;

        context.Courses.Update(course);
        context.SaveChanges();
    }

    public void DeleteCourse()
    {
        Console.WriteLine("Enter code to be Delete");

        string courseCodeTobedelete = Console.ReadLine();

        using var context = new StudentPerformanceContext();
        {
            var courseObj = context.Courses.FirstOrDefault(x => x.Course_Code == courseCodeTobedelete);

            var subjects = context.Subjects.Where(x => x.FK_Course_Id == courseObj.Course_Id).ToList();

            var students = context.Students.Where(x => x.FK_Course_Id == courseObj.Course_Id).ToList();

            foreach (var subject in subjects)
            {
                var subjectId = subject.Subject_Id;

                Console.WriteLine(subjectId);
                var markobj = context.Marks.FirstOrDefault(x => x.FK_Subject_Id == subjectId);
                context.Marks.Remove(markobj);
                context.Subjects.Remove(subject);
            }

            foreach (var student in students)
            {
                context.Students.Remove(student);
            }

            context.Courses.Remove(courseObj);
            context.SaveChanges();
        }
    }
    public void Delete()
    {
        Console.WriteLine("Enter the Course Id to be deleted ");
        var courseIdText = Console.ReadLine();
        var courseIdToBeDeleted = int.Parse(courseIdText);

        using var context = new StudentPerformanceContext();

        var course = context.Courses.FirstOrDefault(xyz => xyz.Course_Id == courseIdToBeDeleted);

        if (course == null)
        {
            Console.WriteLine($"Course with id = {courseIdToBeDeleted} not found");
            return;
        }

        context.Courses.Remove(course);
        context.SaveChanges();

        context.Dispose();
    }
}
