using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;

namespace MySch.Services
{
    class AssignmentService
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<Assignment> GetAll()
        {
            List<Assignment> assignments = new List<Assignment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Assignments", conn))
                    {
                        using (SqlDataReader assignmentsReader = cmd.ExecuteReader())
                        {
                            while (assignmentsReader.Read())
                            {
                                Assignment assignment = new Assignment()
                                {
                                    ID = (int)assignmentsReader["id"],
                                    Title = (string)assignmentsReader["Title"],
                                    Submission = (DateTime)assignmentsReader["Submission"],
                                    Oral = (int)assignmentsReader["Oral"],
                                    Total = (int)assignmentsReader["Total"]
                                };
                                assignments.Add(assignment);
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
            return assignments;
        }

        public void Create()
        {
            Console.WriteLine("Give a title");
            string Title = Console.ReadLine();
            Console.WriteLine("Give a submission date");
            DateTime Submission = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Give an oral mark");
            int Oral = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Give a total mark");
            int Total = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "INSERT INTO Assignments(Title,Submission,Oral,Total) " +
                        "VALUES (@Title,@Submission,@Oral,@Total)";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Title", Title));
                        cmd.Parameters.Add(new SqlParameter("@Submission", Submission));
                        cmd.Parameters.Add(new SqlParameter("@Oral", Oral));
                        cmd.Parameters.Add(new SqlParameter("@Total", Total));
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
