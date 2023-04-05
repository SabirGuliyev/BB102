using AbstractClass.Models;
//using A = AbstractClass.Models.Base.Example;
namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Namespace Examples
            ////Models.Person personAnother= new Models.Person();
            //A.Person personExample = new A.Person();
            //Person person = new Person();
            //personExample.Name = "Example";
            ////personAnother.Name = "Uzaqdaki";
            ////person.A = "Yaxindaki"; 
            #endregion

            #region Readonly defferences
            //Person person = new Person
            //{
            //    Age=20,
            //    Name = "Sabir",
            //    Surname="Guliyev"
            //};


            //Console.WriteLine(Person.WiFiPass);



            //person.Name = "HEllo";
            //person.Surname = "Salam";
            //Console.WriteLine(person.Age); 
            #endregion



           

            //animal.Eat();


            Dog dog = new Dog();
            dog.Name = "tuzik";
            dog.AvgLifeTime = 8;

            Cow cow = new Cow();
            cow.AvgLifeTime = 3;
            //Animal animal = new Dog();
          
            Animal[] animals = {dog,cow};

            foreach (Animal animal in animals)
            {
                animal.MakeSound();
                Console.WriteLine(animal.AvgLifeTime);
               
            }
            int
            Object

            ////dog.MakeSound();
            ////cow.MakeSound();

            //dog.Eat();
            //cow.Eat();



            //Person person = new Person 
            //{ 
            //    Name="Yusif",
            //    Surname="Aliyev",
            //    Age=20
            //};


            //Console.WriteLine(person);



            //Student student = new Student
            //{
            //    Name = "Fidan",
            //    Surname = "Baratli",
            //    Age = 20,
            //    GroupName="BB102"
            //};
            //Console.WriteLine(student);
            //person.GetInfo();
            //student.GetInfo();


        }
    }






    #region Namespace example2
    //internal class Person
    //{
    //    public string A { get; set; }
    //} 
    #endregion
}