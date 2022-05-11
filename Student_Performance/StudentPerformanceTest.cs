using Student_Performance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance;

internal class StudentPerformanceTest
{
    string s = new string('-', 100);
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
                Console.WriteLine($"| {course.Course_Id, -9} | {course.Course_Code, -11} | {course.Course_Title, -12} | {course.Course_Description, -18} |");
            }
            Console.WriteLine(s);

            //------------------------------------------------------------------------------------------------------------------------------------------------------------

            var students = Context.Students.ToList();

            Console.WriteLine("---------------Student------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Roll No | Student Name         | Student Email       | Student Address | Course Title |");
            Console.WriteLine(s);

            foreach (var student in students)
            {
                Console.WriteLine($"| {student.Student_Roll_No, -7} | {student.Student_Name, -20} | {student.Student_email, -19} | {student.Student_Address, -15} | {student.course.Course_Title, -12} |");
            }
            Console.WriteLine(s);

            //------------------------------------------------------------------------------------------------------------------------------------------------------------

            var subjects = Context.Subjects.ToList();

            Console.WriteLine("---------------Subject------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Subject Code | Subject Title           | Course Code | Course Title |");
            Console.WriteLine(s);

            foreach (var subject in subjects)
            {
                Console.WriteLine($"| {subject.Subject_Code, -12} | {subject.Subject_Title, -23} | {subject.course.Course_Code, -11} | {subject.course.Course_Title, -12} |");
            }
            Console.WriteLine(s);

            //------------------------------------------------------------------------------------------------------------------------------------------------------------

            var marks = Context.Marks.ToList();


            Console.WriteLine("---------------Marks------------------");

            Console.WriteLine(s);
            Console.WriteLine("| Student Name         | Subject Title           | Marks |");
            Console.WriteLine(s);

            foreach (var mark in marks)
            {
                Console.WriteLine($"| {mark.student.Student_Name, -20} | {mark.subject.Subject_Title, -23} | {mark.marks,-5} |");
            }
            Console.WriteLine(s);

            //------------------------------------------------------------------------------------------------------------------------------------------------------------

        }
    }
}
