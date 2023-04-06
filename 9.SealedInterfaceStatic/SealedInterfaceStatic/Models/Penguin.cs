using SealedInterfaceStatic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic.Models
{
    internal class Penguin : Bird,ISwim
    {
       

        public override void MakeSound()
        {
            Console.WriteLine("Sound like penguin");
        }

        public void Swim()
        {

            Console.WriteLine("Bomba uzur");
        }
    }
}
