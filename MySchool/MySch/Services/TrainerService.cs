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
    class TrainerService : ITrainer
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<Trainer> GetAll()
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Trainers", conn))
                    {
                        using (SqlDataReader trainersReader = cmd.ExecuteReader())
                        {
                            while (trainersReader.Read())
                            {
                                Trainer trainer = new Trainer()
                                {
                                    ID = (int)trainersReader["id"],
                                    FirstName = (string)trainersReader["FirstName"],
                                    LastName = (string)trainersReader["LastName"],
                                    Subject = (string)trainersReader["Subject"]
                                };
                                trainers.Add(trainer);
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
            return trainers;
        }

        public List<TrainersPerCourse> AllTrainersPerAllCourses()
        {
            List<Course> courses = new CourseService().GetAll();
            List<Trainer> trainers = GetAll();
            List<TrainerCourse> trainerCourses = new TrainerCourseService().GetAll();

            var query = from t in trainers
                        join tc in trainerCourses
                        on t.ID equals tc.TrainerId
                        join c in courses
                        on tc.CourseId equals c.ID
                        select new { Course = c, Trainer = t };

            var groupedByCourse = query.GroupBy(g => g.Course);

            List<TrainersPerCourse> allTrainersPerAllCourses = new List<TrainersPerCourse>();
            foreach (var group in groupedByCourse)
            {
                TrainersPerCourse trainersPerCourse = new TrainersPerCourse();

                trainersPerCourse.Course = group.Key;
                foreach (var item in group)
                {
                    trainersPerCourse.Trainers.Add(item.Trainer);
                }

                allTrainersPerAllCourses.Add(trainersPerCourse);
            }
            return allTrainersPerAllCourses;
        }

        public void Create()
        {
            Console.WriteLine("Give firstname");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Give lastname");
            string LastName = Console.ReadLine();
            Console.WriteLine("Give subject");
            string Subject = Console.ReadLine();
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "INSERT INTO Trainers(FirstName,LastName,Subject) " +
                        "VALUES (@FirstName,@LastName,@Subject)";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
                        cmd.Parameters.Add(new SqlParameter("@Subject", Subject));
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
