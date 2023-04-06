using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExamples.Models
{
    internal class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
           // Person person = new Person("Sabir");
           //Name= person.Capitalize(name);


            Name=Person.Capitalize(name);

        }

    }
}
