using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;

namespace MySch.ViewModels
{
    class StudentsPerCourse
    {
        public Course Course { get; set; }
        public List<Student> Students = new List<Student>();
    }
}
