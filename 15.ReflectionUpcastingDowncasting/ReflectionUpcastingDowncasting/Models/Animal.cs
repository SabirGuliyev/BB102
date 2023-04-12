using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUpcastingDowncasting.Models
{
    internal abstract class Animal
    {
        public byte AvgLifeTime { get; set; }
        public virtual void Eat()
        {
            Console.WriteLine("Yem ile qidalanir");
        }
        public abstract void MakeSound();
    }
}
