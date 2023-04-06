using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic.Models
{
    internal abstract class Bird:Animal
    {
        public string Wing { get; set; }

        //public virtual void Fly()
        //{
        //    Console.WriteLine("Bird flied");
        //}
    }
}
