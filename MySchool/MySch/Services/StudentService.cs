using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.Interfaces;
using MySch.ViewModels;

namespace MySch.Services
{
    class StudentService : IStudent
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn))
                    {
                        using (SqlDataReader studentsReader = cmd.ExecuteReader())
                        {
                            while (studentsReader.Read())
                            {
                                Student student = new Student()
                                {
                                    ID = (int)studentsReader["id"],
                                    FirstName = (string)studentsReader["FirstName"],
                                    LastName = (string)studentsReader["LastName"],
                                    Birthday = (DateTime)studentsReader["Birthday"],
                                    Tuition = (int)studentsReader["Tuition"]
                                };
                                students.Add(student);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"SqlException {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"General exception {e.Message}");
                }
            }
            return students;
        }

        public List<StudentsPerCourse> AllStudentsPerAllCourses()
        {
            List<Course> courses = new CourseService().GetAll();
            List<Student> students = GetAll();
            List<StudentCourse> studentCourses = new StudentCourseService().GetAll();

            var query = from s in students
                        join sc in studentCourses
                        on s.ID equals sc.StudentId
                        join c in courses
                        on sc.CourseId equals c.ID
                        select new { Course = c, Student = s };

            var groupedByCourse = query.GroupBy(g => g.Course);

            List<StudentsPerCourse> allStudentsPerAllCourses = new List<StudentsPerCourse>();
            foreach (var group in groupedByCourse)
            {
                StudentsPerCourse studentsPerCourse = new StudentsPerCourse();

                studentsPerCourse.Course = group.Key;
                foreach (var item in group)
                {
                    studentsPerCourse.Students.Add(item.Student);
                }

                allStudentsPerAllCourses.Add(studentsPerCourse);
            }
            return allStudentsPerAllCourses;
        }

        public void Create()
        {
            Console.WriteLine("Give a first name");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Give a last name");
            string LastName = Console.ReadLine();
            Console.WriteLine("Give the birth date");
            DateTime Birthday = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Give the tuition fees");
            int Tuition = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "INSERT INTO Students(FirstName,LastName,Birthday,Tuition) " +
                        "VALUES (@FirstName,@LastName,@Birthday,@Tuition)";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
                        cmd.Parameters.Add(new SqlParameter("@Birthday", Birthday));
                        cmd.Parameters.Add(new SqlParameter("@Tuition", Tuition));
                        int rowsInserted = cmd.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            Console.WriteLine("Insertion Successful");
                            Console.WriteLine($"{rowsInserted} rows inserted Successfully");
                        }
                    }

                }
                catch (SqlException e)
                {
                    Console.WriteLine($"SqlException {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"General exception {e.Message}");
                }
            }
        }
    }
}
