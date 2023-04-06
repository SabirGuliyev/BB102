using SealedInterfaceStatic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic.Models
{
    internal class Eagle:Bird,IFly
    {
        public string Claw { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("chaww");
        }
        public void Fly()
        {
            Console.WriteLine("Eagle flied");
        }
    }
}
