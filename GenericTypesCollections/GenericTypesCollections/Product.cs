using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesCollections
{
    internal class Product<T> 
    {
        
        public T Quality { get; set; }

      
        public Product(T quality)
        {
            Quality = quality;
        }
    }
}
