using Base_String_Regex_Array.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace Base_String_Regex_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("Sabir","Guliyev",25);
            //Student student = new Student();


            #region String Methods

            //string name =Console.ReadLine().Trim().ToLower();
            //string name = "Sabir Guliyev Mehti";
            //string[] sentence = { "Hello", "World", "People" };
            //name=name.Trim().ToLower().Replace(' ','-');
            //name.ToLower();
            //name.ToUpper();
            //name.Trim();
            //name = name.Replace("77", "Salam");
            //name.Contains('t');
            //name.EndsWith("123");
            //name.IndexOf('r');

            //string firstPart=name.Substring(0,2);
            //string secondPart=name.Substring(6,2);
            //char[] words =name.ToCharArray();
            //name.Split('e')
            //String.Concat(word, " ", "Gencler");
            //"Salam" + " " + "Gencler"
            //String.Join("", sentence); 
            #endregion

            #region Array Methods
            //int[] arr = { 7,6,8 };
            //int[] arr2 = new int[arr.Length];

            //int[] arr2 = new int[4];
            //int[] arr3 = new int[4] {1,2,3,4};
            //arr.Min();
            //arr.Max();
            //arr.Sum();
            //arr.Average();
            //arr=arr.Append(45).ToArray();
            //arr=arr.Reverse().ToArray();
            //arr.SetValue(20, 0);
            //arr[0] = 20;
            //arr.CopyTo(arr2, 0);
            //arr2[0] = 45;

            //Array.ForEach(arr2, item => Console.WriteLine(item));

            //Array.Sort(arr);
            //Array.Reverse(arr);
            //Array.Clear(arr);
            //Array.Fill(arr,20);
            //Console.WriteLine(Array.IndexOf(arr, 6));
            //Console.WriteLine(Array.LastIndexOf(arr, 6));
            //Array.ForEach(arr, item => Console.WriteLine(item));

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //} 
            #endregion

            #region Regex
            //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


            //Console.WriteLine(regex.IsMatch("sabir..98@gmail.com")); 
            #endregion


            //Mutable Immutable
            //string word = "a";

            //word += " Necesen";

            //word += " Gencler";

            //string name=Console.ReadLine().Trim();
            // name=Capitalize(name);  
            // Console.WriteLine(name);

            //Person person= new Person("aZadE");

            //string name = "Sa111114325";
            //for (int i = 0; i < name.Length; i++)
            //{
            //    if (Char.IsDigit(name[i]))
            //    {
            //        Console.WriteLine(name[i]);
            //    }
            //}




        }
        public static string Capitalize(string name)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append(Char.ToUpper(name[0]));

            for (int i = 1; i < name.Length; i++)
            {
                sb.Append(Char.ToLower(name[i]));
            }

            return sb.ToString();
        }
    }
}