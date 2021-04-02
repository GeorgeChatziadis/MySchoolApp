using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class Trainer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" Trainer's ID: ");
            sb.Append(ID);
            sb.Append(" First name: ");
            sb.Append(FirstName);
            sb.Append(" Last name: ");
            sb.Append(LastName);
            sb.Append(" Trainer's subject: ");
            sb.Append(Subject);
            return sb.ToString();
        }
    }
}
