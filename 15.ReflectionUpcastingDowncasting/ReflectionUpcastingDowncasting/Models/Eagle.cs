using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUpcastingDowncasting.Models
{
    internal class Eagle : Animal
    {
        public void Fly()
        {
            Console.WriteLine("Eagle flied");
        }
        public override void MakeSound()
        {
            Console.WriteLine("sound like Eagle");
        }
    }
}
