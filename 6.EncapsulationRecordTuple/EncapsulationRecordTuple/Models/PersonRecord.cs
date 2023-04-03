using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationRecordTuple.Models
{
    internal record PersonRecord
    {
        private string _name;
        private string _surname;

        public string Name { get { return _name; } init { _name = value; } }

        public string Surname { get { return _surname; } init { _surname = value; } }
        public PersonRecord(string name, string surname)
        {
            //Name = name;
            //Surname = surname;
            (Name,Surname)=(name,surname);

        }

    }
    //internal record PersonRecord(string Name,string Surname);

}
