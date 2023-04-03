using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationRecordTuple.Models
{
    internal class Group
    {
        public string Name;
        public Student[] Students;


        public Group()
        {
            Students = new Student[0];
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref Students, Students.Length+1);
            Students[Students.Length-1] = student;

        }
    }
}
