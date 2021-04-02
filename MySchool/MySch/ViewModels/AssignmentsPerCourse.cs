using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;

namespace MySch.ViewModels
{
    class AssignmentsPerCourse
    {
        public Course Course { get; set; }
        public List<Assignment> Assignments = new List<Assignment>();
    }
}
