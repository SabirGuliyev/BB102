using ClassObject.Models;

namespace ClassObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string name = "Fidan";
            //string surname = "Baratli";
            //byte age = 20;

            //Console.WriteLine(name+" "+surname+" "+age);
            //Console.WriteLine("{0} {1} {2}",name,surname,age);


            //string name2 = "Yusif";
            //string surname2 = "Aliyev";
            //byte age2 = 20;
            //Console.WriteLine($"{name} {surname} {age}");
            //Console.WriteLine($"{name2} {surname2} {age2}");

            #region Anonim Object

            //object person = new
            //{
            //    Name="Yusif",
            //    Age=20

            //};
            //object person2 = new
            //{
            //    Name = "Fidan",
            //    Surname = "Baratli"

            //};

            //Console.WriteLine(person.GetType().GetProperty("Name").GetValue(person)); 
            #endregion

            //int[] arr = new int[0];
            //Person person=new Person();
            //person.Name = "Yusif";
            //person.Surname = "Aliyev";
            //person.Age = 20;



            //Person person2=new Person
            //{
            //    Name="Fidan",
            //    Surname="Baratli",
            //    Age=20
            //};

            //person2.GetInfo();
            //person.GetInfo();


            //person2.GetPersonInfo(person2);

            //Console.WriteLine($"{person.Name} {person.Surname} {person.Age}");
            //Console.WriteLine($"{person2.Name} {person2.Surname} {person2.Age}");


            //int[] arr;




            //Person person3 = new Person(age:20,name:"Yusif",surname:"Aliyev");

            //person3.GetInfo();
           

            //person3.GetInfo();



            //Person person4 = new Person();
            //Person person5 = new Person("Azade");
            //Person person5 = new Person("Yusif","Aliyev",20);
            //person5.GetInfo();
            //person5.GetInfo();
            //Person person6 = new Person("Fidan", "Baratli");
            //Person person7 = new Person("Yusif","Aliyev",20);

            
          Student student = new Student("Yusif");
          
            student.Surname = "Aliyev";
            student.Age = 20;

            student.Course = 3;
            student.Subject = "C#";

            //student.GetInfo();

        Teacher teacher = new Teacher("sabir");
            
            teacher.Surname = "Guliyev";
            teacher.Age = 25;
            teacher.Salary = 23456;

            Console.WriteLine(teacher.Salary);






        }
    }
    class Person
    {
        //Fields
        public string Name;

        public string Surname;

        public byte Age;

        //constructor
        public Person()
        {
            Console.WriteLine("Person created");
        }
        public Person(string name):this()
        {
            Name = name;
        }
        public Person(string name, string surname) : this(name)
        {
            Surname = surname;
        }

        public Person(string name, string surname, byte age) : this(name, surname)
        {
            Age = age;
        }

        //Method
        public void GetInfo()
        {
            Console.WriteLine($"Name:{Name} Surname:{Surname} Age:{Age}");
        }
        //public Person GetPersonInfo(Person person)
        //{
        //    Console.WriteLine($"{person.Name} {person.Surname} {person.Age}");
        //    return person;
        //}

        //Constants
        //Property
        //Indexer
        //Finalizer


    }
}