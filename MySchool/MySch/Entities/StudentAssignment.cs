using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class StudentAssignment
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("ID: ");
            sb.Append(ID);
            sb.Append(" Student ID: ");
            sb.Append(StudentId);
            sb.Append(" Assignment ID: ");
            sb.Append(AssignmentId);
            return sb.ToString();
        }
    }
}
