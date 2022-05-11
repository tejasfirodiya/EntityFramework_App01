// See https://aka.ms/new-console-template for more information
using Student_Performance;
using Student_Performance.DataAccess.Models;
using Student_Performance.DataAccess.Services;

Console.WriteLine("Hello, World!");

//StudentPerformanceTest studentPerformanceTest = new StudentPerformanceTest();
//studentPerformanceTest.Select();

//CourseService courseService = new CourseService();
//courseService.Select();
//courseService.Add();
//courseService.Update();
//courseService.Delete();
//courseService.Select();

//StudentService studentService = new StudentService();
//studentService.Select();
//studentService.Add();
//studentService.Update();
//studentService.Delete();
//studentService.Select();

//SubjectService subjectService = new SubjectService();
//subjectService.Select();
//subjectService.Add();
//subjectService.Update();
//subjectService.Delete();
//subjectService.Select();

MarksService marksService = new MarksService();
marksService.Select();
//marksService.Add();
marksService.Update();
//marksService.Delete();
marksService.Select();
