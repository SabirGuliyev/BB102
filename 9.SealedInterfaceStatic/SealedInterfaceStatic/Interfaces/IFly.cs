using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic.Interfaces
{
    internal interface IFly
    {
        //public string Name;
        public void Fly();
        public int MyProperty { get; set; }


    }
}
