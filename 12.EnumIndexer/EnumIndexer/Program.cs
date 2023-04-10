using EnumIndexer.Enums;
using EnumIndexer.Models;

namespace EnumIndexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region EnumExamples
            //int num = int.Parse(Console.ReadLine());
            //Console.WriteLine("Reserv gununu secin");
            //int num;
            //string answer=Console.ReadLine();
            //int.TryParse(answer, out num);


            //switch (num)
            //{
            //    case (int)CusDayOfWeek.Monday:

            //        Console.WriteLine(CusDayOfWeek.Monday);
            //        break;
            //    case (int)CusDayOfWeek.Tuesday:

            //        Console.WriteLine(CusDayOfWeek.Tuesday);
            //        break ;
            //    case (int)CusDayOfWeek.Wednesday:

            //        Console.WriteLine(CusDayOfWeek.Wednesday);
            //        break;
            //    case (int)CusDayOfWeek.Thursday:

            //        Console.WriteLine(CusDayOfWeek.Thursday);
            //        break;
            //    case (int)CusDayOfWeek.Friday:

            //        Console.WriteLine(CusDayOfWeek.Friday);
            //        break;
            //    case (int)CusDayOfWeek.Saturday:

            //        Console.WriteLine(CusDayOfWeek.Saturday);
            //        break;
            //    case (int)CusDayOfWeek.Sunday:

            //        Console.WriteLine(CusDayOfWeek.Sunday);
            //        break;
            //    default:
            //        Console.WriteLine("Wrong input");
            //        break;
            //}
            //Console.WriteLine("Film novunu secin");






            //foreach (var item in Enum.GetValues(typeof(MovieCategory)))
            //{
            //    Console.WriteLine((int)item + " " + item);
            //}
            //int choice;
            //string answer2 = Console.ReadLine();
            //int.TryParse(answer2, out choice);

            //Group groupEx = new Group("Example");
            //string name = "";
            //Group group;
            //switch (choice)
            //{
            //    case (int)MovieCategory.Horror:
            //        name = $"H{Group.Count}";
            //        group = new Group(name);
            //        Console.WriteLine(group.Name);
            //        break;
            //    case (int)MovieCategory.Comedy:
            //        name = $"C{Group.Count}";
            //        group = new Group(name);
            //        Console.WriteLine(group.Name);

            //        break;
            //    default:
            //        Console.WriteLine("Bele categoriya yoxdur");
            //        break;
            //}


            //(byte)ProductCategory.Phone 
            #endregion


            List<int> numbers=new List<int>();



            ListInt nums = new ListInt(2);
            ListInt nums2= new ListInt(5,6,7,8,9,10);
            nums2.Add(15);
            //nums2[6] = 20;
            for (int i = 0; i < nums2.Length; i++)
            {
                Console.WriteLine(nums2[i]);
            }

           
            //Console.WriteLine(nums[0]);
            //Console.WriteLine(nums2[20]);





        }
    }
}