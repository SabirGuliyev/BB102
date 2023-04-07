using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtensionStruct.Models
{
    internal class PointClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointClass()
        {

        }
        public PointClass(int x)
        {
            X = x;
        }
    }

    internal struct PointStruct:ITest
    {
        
        public int X { get; set; }
        int Y { get; set; }
        public bool IsHigh { get; set; }
        public int Test { get; set; }

        public PointStruct(int x)
        {
            X=0;
            Y = 0;
            IsHigh = false;
            Test = 0;
        }
    }
    internal interface ITest
    {
        public int Test { get; set; }
    }
}
