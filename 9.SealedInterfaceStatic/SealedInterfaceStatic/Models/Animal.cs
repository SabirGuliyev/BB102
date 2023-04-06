using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic.Models
{
    internal abstract class Animal
    {
        public byte AvgLifeTime { get; set; }

        public abstract void MakeSound();

        public virtual void Eat()
        {
            Console.WriteLine("Yem ile qidalanir");
        }
        public void getinfo()
        {
            Console.WriteLine();
        }
       
    }
}
