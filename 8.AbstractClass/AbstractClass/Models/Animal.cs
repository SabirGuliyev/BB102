using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Models
{
    internal abstract class Animal
    {
        public byte AvgLifeTime { get; set; }

        

        public Animal()
        {
            //Console.WriteLine("animalin ctoru ishe dushdu");
        }

        public virtual void Eat()
        {
            Console.WriteLine("Yem yeyir");
        }
        public abstract void MakeSound();
       
        
    }
}
