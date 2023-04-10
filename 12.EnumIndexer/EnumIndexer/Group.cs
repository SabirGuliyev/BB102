using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumIndexer
{
    internal class Group
    {
        public static int Count { get; set; } = 100;
        public string Name { get; set; }
        public Group(string name)
        {
            Name = name;
            Count++;
        }
    }
}
