using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.Services;
using MySch.ViewModels;

namespace MySch
{
    class Program
    {
        static void Main(string[] args)
        {


            School school = new School();
            school.Run();
        }
    }
}
