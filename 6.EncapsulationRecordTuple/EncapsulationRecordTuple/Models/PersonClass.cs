using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationRecordTuple.Models
{
    internal class PersonClass
    {

        private string _name;
        private string _surname;

        public string Name { get { return _name; } set { _name = value; } }

        public string Surname { get { return _surname; } set { _surname = value; } }
        public PersonClass(string name, string surname)
        {
            Name = name;
            Surname = surname;
         
        }
    }
}
