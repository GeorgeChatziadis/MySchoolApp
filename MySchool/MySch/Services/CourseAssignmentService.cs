using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.ViewModels;

namespace MySch.Services
{
    class CourseAssignmentService
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<CourseAssignment> GetAll()
        {
            List<CourseAssignment> courseAssignments = new List<CourseAssignment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM CourseAssignments", conn))
                    {
                        using (SqlDataReader assignmentsReader = cmd.ExecuteReader())
                        {
                            while (assignmentsReader.Read())
                            {
                                CourseAssignment courseAssignment = new CourseAssignment()
                                {
                                    ID = (int)assignmentsReader["ID"],
                                    CourseId = (int)assignmentsReader["CourseID"],
                                    AssignmentId = (int)assignmentsReader["AssignmentID"]
                                };
                                courseAssignments.Add(courseAssignment);
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
            return courseAssignments;
        }

       public List<AssignmentsPerCourse> AllAssignmentsPerAllCourses()
        {
            List<Course> courses = new CourseService().GetAll();
            List<Assignment> assignments = new AssignmentService().GetAll();
            List<CourseAssignment> courseAssignments = GetAll();

            var query = from a in assignments
                        join ca in courseAssignments
                        on a.ID equals ca.AssignmentId
                        join c in courses
                        on ca.CourseId equals c.ID
                        select new { Course = c, Assignment = a };

            var groupedByCourse = query.GroupBy(g => g.Course);

            List<AssignmentsPerCourse> allAssignmentsPerAllCourses = new List<AssignmentsPerCourse>();
            foreach (var group in groupedByCourse)
            {
                AssignmentsPerCourse assignmentsPerCourse = new AssignmentsPerCourse();

                assignmentsPerCourse.Course = group.Key;
                foreach (var item in group)
                {
                    assignmentsPerCourse.Assignments.Add(item.Assignment);
                }

                allAssignmentsPerAllCourses.Add(assignmentsPerCourse);
            }
            return allAssignmentsPerAllCourses;
        }
    }
}
