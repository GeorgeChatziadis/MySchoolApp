using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySch.Entities
{
    class Assignment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Submission { get; set; }
        public int Oral { get; set; }
        public int Total { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" Assignment ID: ");
            sb.Append(ID);
            sb.Append(" Title: ");
            sb.Append(Title);
            sb.Append(" Submission date: ");
            sb.Append(Submission);
            sb.Append(" Oral mark: ");
            sb.Append(Oral);
            sb.Append(" Total mark: ");
            sb.Append(Total);
            return sb.ToString();

        }

    }
}
