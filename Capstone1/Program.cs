using System;
using System.Collections.Generic;
using ConstosoModel;
using DataAccess;

namespace Capstone1
{
    class Program
    {

        static List<Course> courses = new List<Course>();
        static string mainAction = "A"; // A - Add, D - Display
        static int subAction = 2;  // 1 - Display Student/Course , 2 - Add Student/Course
        static void Main(string[] args)
        {
            while (mainAction != "Q")
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("Press (A) to Add Data");
                Console.WriteLine("Press (D) to Display Data");
                Console.WriteLine("Press (Q) to Quit");
                Console.WriteLine("======================================");
                mainAction = Console.ReadLine();

                if (mainAction == "A")
                {
                    AddData();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        AddStudent();
                    }
                    else if (subAction == 2)
                    {
                        AddNewCourses();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                        Console.ReadLine();
                    }
                }
                else if (mainAction == "D")
                {
                    DisplayData();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        DisplayStudent();
                    }
                    else if (subAction == 2)
                    {
                        DisplayCourses();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                    Console.ReadLine();
                    return;
                }
            }
        }
        static void AddData()
        {
            Console.WriteLine("Press (1) to Add Students");
            Console.WriteLine("Press (2) to Add Courses");
            Console.WriteLine("Press (Q) to Quit");
        }

        static void AddStudent()
        {
            Console.WriteLine("Enter Course name");
            string coursename = Console.ReadLine();
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            int courseid = db.FindCourse(coursename);
            if (courseid == 0)
            {
                Console.WriteLine("No such course exists");
            }
            else
            {
                Student student = new Student();
                Console.WriteLine("Enter student name");
                student.name = Console.ReadLine();

                Console.WriteLine("Enter student marks");
                string marks = Console.ReadLine();
                int markschecked = 0;
                if (int.TryParse(marks, out markschecked)== true)
                {
                    student.marks = markschecked;
                    student.courseId = courseid;
                    db.SaveStudent(student);
                }
                else
                {
                    Console.WriteLine("Marks should be numeric");
                }
            }
        
            Console.ReadLine();
        }
        static void AddNewCourses()
        {
            Course course = new Course();
            Console.WriteLine("Enter Course Name");
            course.name = Console.ReadLine();
            //courses.Add(course);
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            db.SaveCourse(course);
            Console.ReadLine();
        }
        static void DisplayData()
        {
            Console.WriteLine("Press (1) to Display Students");
            Console.WriteLine("Press (2) to Display Courses");
            Console.WriteLine("Press (Q) to Quit");
        }

        static void DisplayStudent()
        {
            foreach (var item in courses)
            {
                Console.WriteLine(item.name);
                foreach (var stud in item.students)
                {
                    Console.WriteLine("-->" + stud.name + " " + stud.marks);
                }
            }
            Console.ReadLine();

        }
        static void DisplayCourses()
        {
            CourseStudentDataAccess db = new CourseStudentDataAccess();

            List<Course> courses = db.getCourses();
            foreach (var temp in courses)
            {
                Console.WriteLine("Id : " + temp.id + "Course Name : " + temp.name);
            }
            Console.ReadLine();
        }

        

    }
}
