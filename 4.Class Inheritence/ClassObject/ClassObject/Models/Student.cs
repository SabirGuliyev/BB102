using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObject.Models
{
    internal class Student:Person
    {

        public byte Course;
        public string Subject;
        public Student(string name):base(name)
        {

        }
        public Student(string name, string surname):base(name,surname)
        {

        }
     
    }
}
