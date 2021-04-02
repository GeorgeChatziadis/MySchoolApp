using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class StudentCourse
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("ID: ");
            sb.Append(ID);
            sb.Append(" Student's ID: ");
            sb.Append(StudentId);
            sb.Append(" Course ID: ");
            sb.Append(CourseId);
            return sb.ToString();
        }
    }
}
