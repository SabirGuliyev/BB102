using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Models
{
    internal class Person
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }

        //public virtual void GetInfo()
        //{
        //    Console.WriteLine($"{Name} {Surname} {Age}");
        //}

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }











        #region Namespace example
        //public const string WiFiPass = "Salam123";
        ////public readonly string Surname="XXX";

        ////public string Name { get; } = "YYY";

        ////public byte Age { get; init; } = 12;
        //public Person()
        //{
        //    //Surname=surname;
        //    //Name=name;

        //    //Age = age;


        //} 
        #endregion
    }
}
