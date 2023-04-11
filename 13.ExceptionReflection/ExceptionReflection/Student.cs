using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionReflection
{
    internal class Student
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set {

                if (value.Trim().Length>=3)
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new Exception("Name deyeri yanlish oldugu ucun program dayandirildi");
                }


            }
               
        }
        public Student(string name)
        {
            Name = name;
        }

    }
}
