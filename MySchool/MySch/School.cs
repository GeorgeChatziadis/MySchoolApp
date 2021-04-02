using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.Services;
using MySch.ViewModels;

namespace MySch
{
    class School
    {
        public void Run()
        {
            Console.WriteLine("Press 1 to read Data.");
            Console.WriteLine("Press 2 to input Data.");
            bool end = false;
            do
            {
                string input;
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("Press 1 for a list of all the students.");
                            Console.WriteLine("Press 2 for a list of all the trainers.");
                            Console.WriteLine("Press 3 for a list of all the courses.");
                            Console.WriteLine("Press 4 for a list of all the assignments.");
                            Console.WriteLine("Press 5 for all the assignments per course.");
                            Console.WriteLine("Press 6 for all the trainers per course.");
                            Console.WriteLine("Press 7 for all the students per course.");
                            bool end1 = false;
                            do
                            {
                                string input1;
                                input1 = Console.ReadLine();
                                switch (input1)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("A list of all the students.");
                                            Console.WriteLine();
                                            List<Student> students1 = new StudentService().GetAll();

                                            foreach (Student student in students1)
                                            {
                                                Console.WriteLine(student);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("A list of all the trainers.");
                                            Console.WriteLine();

                                            List<Trainer> trainers1 = new TrainerService().GetAll();

                                            foreach (Trainer trainer in trainers1)
                                            {
                                                Console.WriteLine(trainer);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("A list of all the courses.");
                                            Console.WriteLine();

                                            List<Course> courses1 = new CourseService().GetAll();

                                            foreach (Course course in courses1)
                                            {
                                                Console.WriteLine(course);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case "4":
                                        {
                                            Console.WriteLine("A list of all the assignments");
                                            Console.WriteLine();
                                            List<Assignment> assignments1 = new AssignmentService().GetAll();

                                            foreach (Assignment assignment in assignments1)
                                            {
                                                Console.WriteLine(assignment);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case "5":
                                        {
                                            Console.WriteLine("All the assignments per course.");
                                            Console.WriteLine();

                                            List<AssignmentsPerCourse> allAssignmentPerAllCourses = new CourseAssignmentService().AllAssignmentsPerAllCourses();

                                            foreach (var group in allAssignmentPerAllCourses)
                                            {
                                                Console.WriteLine(group.Course.Title);
                                                foreach (Assignment assignment in group.Assignments)
                                                {
                                                    Console.WriteLine($"\t{assignment.Title}");
                                                }
                                            }
                                            break;
                                        }
                                    case "6":
                                        {
                                            Console.WriteLine("All the trainers per course.");
                                            Console.WriteLine();

                                            List<TrainersPerCourse> allTrainersPerAllCourses = new TrainerService().AllTrainersPerAllCourses();

                                            foreach (var group in allTrainersPerAllCourses)
                                            {
                                                Console.WriteLine(group.Course.Title);
                                                foreach (Trainer trainer in group.Trainers)
                                                {
                                                    Console.WriteLine($"\t{trainer.FirstName} {trainer.LastName}");
                                                }
                                            }
                                            break;
                                        }
                                    case "7":
                                        {
                                            Console.WriteLine("All the students per course.");
                                            Console.WriteLine();

                                            List<StudentsPerCourse> allStudentsPerAllCourses = new StudentService().AllStudentsPerAllCourses();

                                            foreach (var group in allStudentsPerAllCourses)
                                            {
                                                Console.WriteLine(group.Course.Title);
                                                foreach (Student student in group.Students)
                                                {
                                                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
                                                }
                                            }
                                            break;
                                        }

                                }
                            } while (!end1);

                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Press 1 to insert a student.");
                            Console.WriteLine("Press 2 to insert a trainer.");
                            Console.WriteLine("Press 3 to insert a course.");
                            Console.WriteLine("Press 4 to insert an assignment.");
                            Console.WriteLine("Press 5 to insert a student into a course.");
                            Console.WriteLine("Press 6 to insert a trainer into a course.");
                            bool end2 = false;
                            do
                            {
                                string input2;
                                input2 = Console.ReadLine();
                                switch (input2)
                                {
                                    case "1":
                                        {
                                            StudentService studentService = new StudentService();

                                            studentService.Create();
                                            foreach (Student s in studentService.GetAll())
                                            {
                                                Console.WriteLine(s);
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            TrainerService trainerService = new TrainerService();

                                            trainerService.Create();
                                            foreach (Trainer t in trainerService.GetAll())
                                            {
                                                Console.WriteLine(t);
                                            }
                                            break;

                                        }
                                    case "3":
                                        {
                                            CourseService courseService = new CourseService();

                                            courseService.Create();
                                            foreach (Course c in courseService.GetAll())
                                            {
                                                Console.WriteLine(c);
                                            }
                                            break;
                                        }
                                    case "4":
                                        {
                                            AssignmentService assignmentService = new AssignmentService();

                                            assignmentService.Create();
                                            foreach (Assignment a in assignmentService.GetAll())
                                            {
                                                Console.WriteLine(a);
                                            }
                                            break;
                                        }
                                    case "5":
                                        {
                                            StudentCourseService studentCourseService = new StudentCourseService();

                                            studentCourseService.Create();
                                            foreach (StudentCourse s in studentCourseService.GetAll())
                                            {
                                                Console.WriteLine(s);
                                            }
                                            break;
                                        }
                                    case "6":
                                        {
                                            TrainerCourseService trainerCourseService = new TrainerCourseService();

                                            trainerCourseService.Create();
                                            foreach (TrainerCourse t in trainerCourseService.GetAll())
                                            {
                                                Console.WriteLine(t);
                                            }
                                            break;
                                        }
                                }
                            } while (!end2);
                            break;
                        }

                        
                }
                
            } while (!end);
        }
    }
}
