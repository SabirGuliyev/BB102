using SealedInterfaceStatic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic.Models
{
    internal class Duck :Bird,ISwimFly
    {
        public void Fly()
        {
            Console.WriteLine("Ucdu getdi");
        }
        public void Swim()
        {
            Console.WriteLine("Uzdu getdi");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Caqk");
        }

        
    }
}
