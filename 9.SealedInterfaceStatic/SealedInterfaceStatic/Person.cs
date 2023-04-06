using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedInterfaceStatic
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        //public Person(string name, string surname)
        //{
        //    Name = name;
        //    Surname = surname;
        //    Console.WriteLine("Person ctor");
        //}

        public virtual void GetInfo()
        {
            Console.WriteLine($"{Name} {Surname}");
        }
    }

    internal class Student:Person
    {
        public string Group { get; set; }
        //public Student(string group,string name,string surname):base(name,surname)
        //{
        //    Group = group;
        //    Console.WriteLine("Student ctor");

        //}

        public sealed override void GetInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Group}");
        }
    }
    internal sealed class Master:Student
    {
        public string Diplom { get; set; }
        //public Master(string diplom,string group,string name,string surname):base(group,name,surname)
        //{
        //    Diplom = diplom;
        //    Console.WriteLine("Master ctor");

        //}

        //public override void GetInfo()
        //{
        //    Console.WriteLine($"{Name} {Surname} {Group} {Diplom}");
        //}
    }

    //internal class Employee:Master
    //{

    //}
}
