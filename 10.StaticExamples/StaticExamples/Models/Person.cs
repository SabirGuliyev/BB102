using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExamples.Models
{
    internal class Person
    {

        public static int Count =0;
        public int Id;
        public string Name;
      
        public Person(string name)
        { 
            Name = Capitalize(name);
            Count++;

            Id = Count;

            Program.SayHello();
        }
        
        public void GetInfo( )
        {
            Console.WriteLine($"{Name} {Id}");
        }

        public static string Capitalize(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Char.ToUpper(name[0]));

            for (int i = 1; i < name.Length; i++)
            {
                sb.Append(Char.ToLower(name[i]));
            }
            return sb.ToString();   
        }
    }
}
