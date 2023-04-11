using ExceptionReflection.Utilities.Exceptions;

namespace ExceptionReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Exception Try Catch
            //try
            //{
            //    string name = "Revan";
            //    int a = int.Parse(Console.ReadLine());
            //    int b = int.Parse(Console.ReadLine());

            //    Console.WriteLine(a / b);
            //    Console.WriteLine(name[10]);
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine("0 ra bolmek olmur ezizim");
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine("Gunah sene guvenendedi");
            //    int a;
            //    string str = Console.ReadLine();
            //    int.TryParse(str, out a);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Qaqa bunu mende gozlemirdim");
            //    Console.WriteLine(e.Message);
            //} 
            #endregion


            string[] names = { "Azade", "Fidan", "Revan", "Yusif" };



            //try
            //{
            //    if (IsExist(names, "Natiq"))
            //    {
            //        Console.WriteLine("Bele shexs movcuddur");
            //    }
            //}
            //catch (NotFoundException e)
            //{

            //    Console.WriteLine(e.Message);
            //}

            //Console.WriteLine("Trydan sonraki kod setirleri");



           
            try
            {
                Student student = new Student("al");
                Console.WriteLine(student.Name);
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("Vacib kodlar ishe dushdu");
            }

            Console.WriteLine("Program cs deki kod");
               
   


        }

        public static bool IsExist(string[] arr, string search)
        {
            

            foreach (string item in arr)
            {
                if (item.ToLower().Trim() == search.ToLower().Trim())
                {
                   
                   return true;
                }
            }
            throw new NotFoundException($"{search} bu sehxs tapilmadi");
        }









        //public static bool IsExist(string[] arr,string search)
        //{
        //    bool result= false;

        //    foreach (string item in arr)
        //    {
        //        if (item.ToLower().Trim()==search.ToLower().Trim())
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}
    }
}