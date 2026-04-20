using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.Model
{
    public class Coworker
    {
       public string Name { get; set; }
       public int Id { get; set;  }

        public Coworker(string name, int id)
        {
            if (id < 1000 || id > 9999)
                throw new ArgumentException("Id must be 4 digits");

            Name = name;
            Id = id;

        }
    }
}
