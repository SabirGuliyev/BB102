using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesCollections.Animals
{
    internal class Elephant:Animal
    {
        public int Size { get; set; }
        public Elephant(string name):base(name)
        {

        }
    }
}
