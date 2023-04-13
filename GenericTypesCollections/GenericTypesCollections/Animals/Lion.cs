using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesCollections.Animals
{
    internal class Lion:Animal
    {
        public string Type { get; set; }
        public Lion(string name):base(name)
        {

        }
    }
}
