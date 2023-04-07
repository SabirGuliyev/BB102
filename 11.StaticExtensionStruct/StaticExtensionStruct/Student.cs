using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtensionStruct
{
    internal class Student
    {
        
        public string Group { get; set; }
        public int Point { get; set; }
        public Student(string group,int point)
        {
            Group=Helper.Capitalize(group);
            Group=group.ExCapitalize();




            Point=point.CustomPow();
        }
        public void ExCapitalizeStu()
        {
            Group = Group.ToUpper();
        }

    }
}
