using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUpcastingDowncasting.Models
{
    internal class Dog : Animal
    {
        public string Name { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Hav Hav");
        }
    }
}
