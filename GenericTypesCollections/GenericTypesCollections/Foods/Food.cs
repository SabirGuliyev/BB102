using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesCollections.Foods
{
    internal abstract class Food
    {
        public string TypeName { get; set; }
        public Food(string typeName)
        {
            TypeName = typeName;
        }

        //public override string ToString()
        //{
        //    return TypeName;
        //}
    }
}
