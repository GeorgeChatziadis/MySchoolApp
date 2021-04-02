using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.Interfaces;

namespace MySch.Services
{
    class TrainerCourseService : ITrainerCourse
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<TrainerCourse> GetAll()
        {
            List<TrainerCourse> trainerCourses = new List<TrainerCourse>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM TrainerCourses", conn))
                    {
                        using (SqlDataReader coursesReader = cmd.ExecuteReader())
                        {
                            while (coursesReader.Read())
                            {
                                TrainerCourse trainerCourse = new TrainerCourse()
                                {
                                    ID = (int)coursesReader["ID"],
                                    CourseId = (int)coursesReader["CourseID"],
                                    TrainerId = (int)coursesReader["TrainerID"]
                                };
                                trainerCourses.Add(trainerCourse);
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
            return trainerCourses;
        }

        public void Create()
        {
            Console.WriteLine("Give Course ID");
            int CourseId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Give  Trainer ID");
            int TrainerId = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "INSERT INTO TrainerCourses(CourseId,TrainerId) " +
                        "VALUES (@CourseId,@TrainerId)";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@CourseId", CourseId));
                        cmd.Parameters.Add(new SqlParameter("@TrainerId", TrainerId));
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
