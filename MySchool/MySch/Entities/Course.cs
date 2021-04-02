using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" Course ID: ");
            sb.Append(ID);
            sb.Append(" Title: ");
            sb.Append(Title);
            sb.Append(" Stream: ");
            sb.Append(Stream);
            sb.Append(" Type: ");
            sb.Append(Type);
            sb.Append(" Start date: ");
            sb.Append(Start);
            sb.Append(" End date: ");
            sb.Append(End);
            return sb.ToString();
        }
    }
}
