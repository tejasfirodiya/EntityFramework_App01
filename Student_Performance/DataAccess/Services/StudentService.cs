using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Student_Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance.DataAccess.Services;

internal class StudentService
{
    string s = new string('-', 100);
    public void Select()
    {
        using (var Context = new StudentPerformanceContext())
        {
            var students = Context.Students.Include("course").ToList();

            Console.WriteLine("---------------Student------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Roll No | Student Name         | Student Email       | Student Address | Course Title |");
            Console.WriteLine(s);

            foreach (var student in students)
            {
                Console.WriteLine($"| {student.Student_Roll_No,-7} | {student.Student_Name,-20} | {student.Student_email,-19} | {student.Student_Address,-15} | {student.course.Course_Title,-12} |");
            }
            Console.WriteLine(s);
        }
    }

    public void Add()
    {
        Student studentObj = new Student();
        var context = new StudentPerformanceContext();

        studentObj.AddStudent();
        var student = new Student
        {
            Student_Roll_No = studentObj.Student_Roll_No,
            Student_Name = studentObj.Student_Name,
            Student_email = studentObj.Student_email,
            Student_Address = studentObj.Student_Address,
            FK_Course_Id = studentObj.FK_Course_Id
        };

        context.Students.Add(student);
        context.SaveChanges();

        context.Dispose();
    }

    public void Update()
    {
        Student studentObj = new Student();

        Console.WriteLine("Enter the Student Roll No to be updated ");
        var studentRollNoText = Console.ReadLine();
        var studentRollNoToBeUpdated = int.Parse(studentRollNoText);

        using var context = new StudentPerformanceContext();

        var student = context.Students.FirstOrDefault(xyz => xyz.Student_Roll_No == studentRollNoToBeUpdated);

        if (student == null)
        {
            Console.WriteLine($"Student with Roll No = {studentRollNoToBeUpdated} not found");
            return;
        }

        studentObj.AddStudent();

        student.Student_Roll_No = studentObj.Student_Roll_No;
        student.Student_Name = studentObj.Student_Name;
        student.Student_email = studentObj.Student_email;
        student.Student_Address = studentObj.Student_Address;
        student.FK_Course_Id = studentObj.FK_Course_Id;

        context.Students.Update(student);
        context.SaveChanges();
    }

    public void Delete()
    {
        Console.WriteLine("Enter the Student Roll No to be deleted ");
        var studentRollNoText = Console.ReadLine();
        var studentRollNoToBeDeleted = int.Parse(studentRollNoText);

        using var context = new StudentPerformanceContext();
        {
            var studentObj = context.Students.FirstOrDefault(x => x.Student_Roll_No == studentRollNoToBeDeleted);

            if (studentObj.Student_Roll_No == null)
            {
                Console.WriteLine($"Student with Roll No = {studentRollNoToBeDeleted} not found");
                return;
            }

            var marks = context.Marks.Where(x => x.FK_Student_Id == studentObj.Student_Id).ToList();

            foreach (var mark in marks)
            {
                context.Marks.Remove(mark);
            }

            context.Students.Remove(studentObj);
            context.SaveChanges();
        }
    }
}

    //public void DeleteUsingSP()
    //{
    //    using var context = new StudentPerformanceContext();

    //    Console.WriteLine("Enter the Student Id to be deleted ");
    //    var studentIdText = Console.ReadLine();
    //    var studentIdToBeDeleted = int.Parse(studentIdText);

    //    var sqlParameterStudentId = new SqlParameter("@Student_Id", System.Data.SqlDbType.BigInt);
    //    sqlParameterStudentId.Value = studentIdToBeDeleted;

    //    var students = context.Set<Student>().FromSqlRaw("[student].[Student_Data_Delete] @Student_Id", sqlParameterStudentId);

    //    //var student = students.Select(x => x.Student_Roll_No);

    //    //var student = context.Students.FirstOrDefault(xyz => xyz.Student_Id == sqlParameterStudentId);
    //    var student = students.Select(x => x.Student_Id);

    //    //if (student == null)
    //    //{
    //    //    Console.WriteLine($"Student with Id = {student} not found");
    //    //    //Console.WriteLine($"Student with Id = 14 not found");
    //    //    return;
    //    //}
    //    //Console.WriteLine("-----------StudentSP-----------");
    //    //foreach (var S in students.Select(x => x.Student_Id))
    //    //{
    //    //    Console.WriteLine($"{S.Student_Id} | {S.Student_Name}");
    //    //}
    //    //Console.WriteLine("----------------------------");
    //    //context.Students.Remove(student);
    //    context.SaveChanges();

    //    context.Dispose();
    //}

