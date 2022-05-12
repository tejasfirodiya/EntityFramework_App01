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
        StudentService studentService = new StudentService();
        SubjectService subjectService = new SubjectService();
        MarksService marksService = new MarksService();

        string s = new string('-', 70);
        int Choice;

        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.WriteLine("\t\t\tStudent Performance Management\t\t\t");
            Console.WriteLine(s);
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. Edit Course");
            Console.WriteLine("3. Delete Course");
            Console.WriteLine("4. Display Course");

            Console.WriteLine("\n5. Add Student");
            Console.WriteLine("6. Edit Student");
            Console.WriteLine("7. Delete Student");
            Console.WriteLine("8. List all students with details of course, subject and total marks");

            Console.WriteLine("\n9. Add Subject");
            Console.WriteLine("10. Edit Subject");
            Console.WriteLine("11. Delete Subject");
            Console.WriteLine("12. Display Subject");

            Console.WriteLine("\n13. Enter Marks of Student");
            Console.WriteLine("14. Delete Marks");
            Console.WriteLine("15. Update Marks");
            Console.WriteLine("16. Display Marks");
            
            //Console.WriteLine("\n13. Ask roll number to display subject wise marks for a student");
            //Console.WriteLine("14. List Course wise average marks");
            //Console.WriteLine("15. List course wise max marks");
            //Console.WriteLine("16. List Course wise topper");
            Console.WriteLine(s);

            Console.Write("\nEnter your choice : ");
            Console.ResetColor();

            Choice = int.Parse(Console.ReadLine());

            switch (Choice)
            {
                case 1:
                    courseService.Add();
                    break;
                case 2:
                    courseService.Update();
                    break;
                case 3:
                    courseService.Delete();
                    break;
                case 4:
                    courseService.Select();
                    break;

                case 5:
                    studentService.Add();
                    break;
                case 6:
                    studentService.Update();
                    break;
                case 7:
                    studentService.Delete();
                    break;
                case 8:
                    studentService.Select();
                    break;

                case 9:
                    subjectService.Add();
                    break;
                case 10:
                    subjectService.Update();
                    break;
                case 11:
                    subjectService.Delete();
                    break;
                case 12:
                    subjectService.Select();
                    break;

                case 13:
                    marksService.Add();
                    break;
                case 14:
                    marksService.Delete();
                    break;
                case 15:
                    marksService.Select();
                    break;
                case 16:
                    marksService.Update();
                    break;

                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

        } while (Choice != 0);
    }
}
