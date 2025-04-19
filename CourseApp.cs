using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladaprojekt
{
    
        internal class CoursesApp
        {
            public void Run()
            {
                Console.WriteLine("comands you can use: GetCourses,AddCourse,DeleteCourse,UpdateCourse");
                var input = Console.ReadLine();
                while (input != "end")
                {
                    if (input == "GetCourses")
                    {
                        Console.WriteLine("all/by name/by department");
                        input = Console.ReadLine();
                        if (input == "all")
                            GetCourses();
                        else if (input == "by name")
                        {
                            input = Console.ReadLine();
                            GetCourses(input);
                        }
                        else if (input == "by department" || input == "by dep")
                        {
                            input = Console.ReadLine();
                            GetCourses("", input);
                        }
                        else
                        {
                            Console.WriteLine("error - does not exist");
                        }
                    }
                    if (input == "AddCourse")
                    {
                        Console.WriteLine("CourseName;Credits;Department;Description");
                        input = Console.ReadLine();
                        var course = input.Split(";");
                        if (course.Length == 4)
                        {
                            CoursesAdd(course[0], ToInt(course[1]), course[2], course[3]);
                        }
                        else
                            Console.WriteLine("invalid number of elements");
                    }
                    if (input == "DeleteCourse")
                    {
                        Console.WriteLine("Id");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out var id))
                        {
                            DeleteCourse(id);
                        }
                        else
                            Console.WriteLine("NaN");
                    }
                    if (input == "UpdateCourse")
                    {
                        Console.WriteLine("Id;CourseName;Credits;Department;Description");
                        input = Console.ReadLine();
                        var course = input.Split(";");
                        if (course.Length == 5)
                        {
                            UpdateCourses(ToInt(course[0]), course[1], ToInt(course[2]), course[3], course[4]);
                        }
                    }
                    Console.WriteLine("\n \n -----------------------------------------\n");
                    Console.WriteLine("comands you can use: GetCourses,AddCourse,DeleteCourse,UpdateCourse");
                    input = Console.ReadLine();
                }
            }

            public void CoursesAdd(string courseName, int credits, string department, string description)
            {
                var course = new Course
                {
                    CourseName = courseName,
                    Credits = credits,
                    Department = department,
                    Description = description
                };
                using var dbContext = new GetContext();
                dbContext.Add(course);
                dbContext.SaveChanges();

            }

            public void DeleteCourse(int ID)
            {
                using var dbContext = new GetContext();
                var course = dbContext.Course.Find(ID);
                if (course != null)
                {
                    dbContext.Remove(course);
                    dbContext.SaveChanges();
                }
            }

            public void UpdateCourses(int id, string newCourseName, int newCredits, string newDepartment, string newDescription)
            {
                var course = new Course
                {
                    ID = id,
                    CourseName = newCourseName,
                    Credits = newCredits,
                    Department = newDepartment,
                    Description = newDescription
                };
                using var dbContext = new GetContext();
                dbContext.Update(course);
                dbContext.SaveChanges();
            }
            public void GetCourses(string? courseName = null, string? department = null)
            {
                using var dbContext = new GetContext();
                var entities = string.IsNullOrEmpty(courseName) ?
                    dbContext.Course : dbContext.Course.Where(x => x.CourseName == courseName);
                if (string.IsNullOrEmpty(courseName))
                {
                    entities = string.IsNullOrEmpty(department) ?
                    dbContext.Course : dbContext.Course.Where(x => x.Department == department);
                }
            var coueses = entities.Select(x => new CourseDto
            {
                Id = x.ID,
                CourseName = x.CourseName,
                Credits = x.Credits,
                Department = x.Department,
                Description = x.Description
            });


            
                foreach (var course in coueses)
                {
                    Console.WriteLine($"Id: {course.Id}"); Console.WriteLine($"Name: {course.CourseName}");Console.WriteLine($"Credits: {course.Credits}");Console.WriteLine($"Department: {course.Department}");Console.WriteLine($"Description: {course.Description}"); Console.WriteLine("--------------------------");
                }
            }
            
            public int ToInt(string x)

            {

                if (int.TryParse(x, out int result))

                {

                    return result;

                }

                else

                {

                    return 0;

                }

            }
        }
    }

