USE MySchool;
-- A list of all the students
SELECT * FROM Students;

-- A list of all the trainers
SELECT * FROM Trainers;

-- A list of all the assignments
SELECT * FROM Assignments;

-- A list of all the courses
SELECT * FROM Courses;

-- All the students per course
SELECT Students.FirstName, Students.LastName, Courses.Title
FROM((StudentCourses
INNER JOIN Students ON StudentCourses.StudentId = Students.ID)
INNER JOIN Courses ON StudentCourses.CourseId = Courses.ID)

-- All the trainers per course
SELECT Trainers.FirstName, Trainers.LastName, Courses.Title
FROM((TrainerCourses
INNER JOIN Trainers ON TrainerCourses.TrainerId = Trainers.ID)
INNER JOIN Courses ON TrainerCourses.CourseId = Courses.ID)

-- All the assignments per course
SELECT Assignments.Title, Courses.Title
FROM((CourseAssignments
INNER JOIN Assignments ON CourseAssignments.AssignmentId = Assignments.ID)
INNER JOIN Courses ON CourseAssignments.CourseId = Courses.ID)

