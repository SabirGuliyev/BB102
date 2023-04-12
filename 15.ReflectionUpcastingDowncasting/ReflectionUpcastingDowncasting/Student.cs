using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUpcastingDowncasting
{
    internal class Student
    {
        public string StudentName;

        public byte Age { get; set; }

        public Student(string name)
        {
            StudentName = name;
        }
    }
}
