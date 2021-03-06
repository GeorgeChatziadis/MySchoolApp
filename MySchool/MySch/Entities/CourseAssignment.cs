using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class CourseAssignment
    {
        public Course Course { get; set; }
        public int ID { get; set; }
        public int CourseId { get; set; }
        public int AssignmentId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("ID: ");
            sb.Append(ID);
            sb.Append(" Course ID: ");
            sb.Append(CourseId);
            sb.Append(" Assignment ID: ");
            sb.Append(AssignmentId);
            return sb.ToString();
        }
    }
}
