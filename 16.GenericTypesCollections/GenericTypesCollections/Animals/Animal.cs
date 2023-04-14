using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesCollections.Animals
{
    internal abstract class Animal
    {
        public string Name { get; set; }
        public byte AvgLifetime { get; set; }
        public Animal(string name)
        {
            Name = name;
          
        }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
