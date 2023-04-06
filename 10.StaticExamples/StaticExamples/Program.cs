using StaticExamples.Models;

namespace StaticExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Person.Count);
            Person punhan = new Person("Punhan");
            
            Person.Count++;
            //person.Capitalize();
           
       
            //Person.Count = 20;

            string word = "Salam";
            Person.GetInfo
            //Console.WriteLine(Person.Count);


        }
        public static void SayHello()
        {
            Console.WriteLine("Salam");
        }
    }
}