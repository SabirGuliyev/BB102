using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObject.Models
{
    internal class Teacher:Person
    {
 
        public decimal Salary;

        public Teacher(string name):base(name)
        {

        }
    }
}
