using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;

namespace MySch.Interfaces
{
    interface ITrainer
    {
        List<Trainer> GetAll();
        void Create();
    }
}
