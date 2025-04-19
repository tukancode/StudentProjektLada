using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladaprojekt
{
    internal class CourseManagment
    {
        public static void ListAllCourses(GetContext context){
            var courses = context.Course.ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.ID}, Name: {course.CourseName}, Department: {course.Department}, Credits: {course.Credits}");
                Console.WriteLine("i love jews");
            }
        }
    }
}
