using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUpcastingDowncasting
{
    internal class Teacher
    {
        private string TeacherName;
        private readonly string Id;
        public Teacher(string teacherName)
        {
            TeacherName = teacherName;

            Id = teacherName + 20;
        }
    }
}
