using Student_Performance.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance;

public class Menu
{
    public void showMenu()
    {


        CourseService courseService = new CourseService();
        //courseService.Select();

        StudentService studentService = new StudentService();

        SubjectService subjectService = new SubjectService();
        //subjectService.Select();

        MarksService marksService = new MarksService();
        //marksService.Select();
        //marksService.Update();
        //marksService.Delete();

        string s = new string('-', 70);
        int Choice;

        do
        {
            Console.WriteLine(s);
            Console.WriteLine("\t\t\tStudent Performance Management\t\t\t");
            Console.WriteLine(s);
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Add Subject");
            Console.WriteLine("4. Enter Marks of Student");
            Console.WriteLine("5. Edit Student Data");
            Console.WriteLine("6. Edit Course");
            Console.WriteLine("7. Edit Subject");
            Console.WriteLine("8. Delete Student");
            Console.WriteLine("9. Delete Subject");
            Console.WriteLine("10. Delete Course");
            Console.WriteLine("11. Delete Marks");
            Console.WriteLine("12. List all students with details of course, subject and total marks");
            Console.WriteLine("13. Ask roll number to display subject wise marks for a student");
            Console.WriteLine("14. List Course wise average marks");
            Console.WriteLine("15. List course wise max marks");
            Console.WriteLine("16. List Course wise topper");
            Console.WriteLine(s);

            Console.Write("\nEnter your choice : ");
            Choice = int.Parse(Console.ReadLine());

            switch (Choice)
            {
                case 1:
                    studentService.Add();
                   
                    break;
                case 2:
                    courseService.Add();
                    break;
                case 3:
                    subjectService.Add();
                    break;
                case 4:
                    marksService.Add();
                    break;
                case 5:
                    studentService.Update();
                    break;
                case 6:
                    courseService.Update();
                    break;
                case 7:
                    subjectService.Update();
                    break;
                case 8:
                    //studentService.DeleteUsingEntityFramework();
                    //studentService.DeleteUsingSP();
                    break;
                case 9:
                    subjectService.Delete();
                    break;
                case 10:
                    courseService.Delete();
                    courseService.DeleteCourse();
                    break;
                case 11:
                    break;
                case 12:
                    studentService.Select();
                    break;
                case 13:
                    break;
                case 17:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

        } while (Choice != 0);
    }
}
