using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Models
{
    internal class Dog:Animal
    {
        public string Name { get; set; }

        public Dog()
        {
            //Console.WriteLine("dog ctoru ishe dushdu");
        }

        public override void MakeSound()
        {
            Console.WriteLine("hav hav");
        }

        public override void Eat()
        {
            Console.WriteLine("Yem ve et yeyir");
        }
    }

}
