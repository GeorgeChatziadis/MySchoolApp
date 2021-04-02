using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Tuition { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" First name: ");
            sb.Append(FirstName);
            sb.Append(" Last name: ");
            sb.Append(LastName);
            sb.Append(" Student's ID: ");
            sb.Append(ID);
            sb.Append(" Date of birth: ");
            sb.Append(Birthday);
            sb.Append(" Tuition fees: ");
            sb.Append(Tuition);
            return sb.ToString();


        }
    }
}
