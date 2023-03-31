using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_String_Regex_Array.Models
{
    internal class Person
    {
        public string Name;
        public string Surname;
        public byte Age;

        public Person()
        {

        }
        public Person(string name)
        {
            Name = Program.Capitalize(name);
            Console.WriteLine(Name);
        }




    }
}
