using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Models
{
    internal class Student:Person
    {
        public string GroupName { get; set; }

        //public override void GetInfo()
        //{
        //    Console.WriteLine($"{Name} {Surname} {Age} {GroupName}");
        //}
    }
}
