namespace DelegateAnonymousLambdaExpression
{
    internal delegate bool CheckNumber(int n);
    internal delegate void PrintConsole<T>(T s);
   
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Custom Delegate
            //int[] numbers = { 1, 2, 3, 4, 5, 6 };


            //int result = Sum(numbers, n => n % 3 == 0);
            //Console.WriteLine(result);
            //int result2 = Sum(numbers, delegate (int num)
            //{

            //    return num % 3 == 0;
            //});




            //PrintConsole<string> print = PrintUpper;

            //print += PrintLower;
            //print += PrintCapitalize;

            ////print += delegate (string word)
            ////{
            ////    Console.WriteLine(word[0] + " " + word[word.Length - 1]);
            ////};

            //print += s => Console.WriteLine(s[0]);
            //print += PrintFirst;


            ////PrintConsole[] prints = {PrintUpper,PrintLower,PrintCapitalize};


            ////print -= PrintCapitalize;

            ////print("sAlaM");
            ////PrintFirst(5m);





            //PrintConsole<int> printNum = n => Console.WriteLine(n/2);
            //printNum.Invoke(6);

            //PrintConsole<bool> printBool = delegate (bool result)
            //{
            //    Console.WriteLine(result);
            //};

            //printBool.Invoke(true); 
            #endregion

            //Action<int[],char> action = () => Console.WriteLine("Hello");
            //action += PrintUpper;
            //action("salam");


            //Action<int,int,bool,string> action2 = (n, c) => Console.WriteLine(n+" "+c);

            //action2("salam","gencler");

            //Func<int> func =()=>5;

            //Console.WriteLine(func(5));



            //Console.WriteLine(CheckEverything(6,n=>n%2==0));
            //Console.WriteLine(CheckEverything(6, n => n % 2 != 0));
            //Console.WriteLine(CheckEverything(6, n => n >0));
            //Console.WriteLine(CheckEverything(6, n => n < 0));



            List<string> names = new List<string>();
            names.Add("Azade");
            names.Add("Fidan");
            names.Add("Sedef");
            names.Add("Tural");
            names.Add("Azer");

            names.ForEach(n => Console.WriteLine(n));



            foreach (string s in names)
            {
                Console.WriteLine(s);
            }



            //names.RemoveAll(n => n.ToLower().Contains("az"));



            //List<string> seacrh = names.FindAll();


            //Console.WriteLine();





        }

        public static bool CheckEverything(int num, Predicate<int> predicate)
        {
            return predicate(num);
        }

        public static void PrintUpper(string word)
        {
            Console.WriteLine(word.ToUpper());
        }

        public static void PrintLower(string word)
        {
            Console.WriteLine(word.ToLower());
        }

        public static void PrintCapitalize(string name)
        {
            Console.WriteLine(Char.ToUpper(name[0])+name.Substring(1).ToLower());
        }
        public static void PrintFirst(string word)
        {
            Console.WriteLine(word);
        }




        public static int SumPredicate(int[] arr, Predicate<int> func)
        {

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (func(arr[i]))
                {
                    sum += arr[i];
                }
            }
            return sum;
        }

        public static int Sum(int[] arr, Func<int,bool,> func)
        {

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (func(arr[i]))
                {
                    sum += arr[i];
                }
            }
            return sum;
        }
        public static int CusSum(int[] arr,CheckNumber func)
        {
           
            int sum = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (func(arr[i]))
                {
                    sum += arr[i];
                }
            }
            return sum;
        }

        
        public static bool CheckEven(int num)
        {
            return num%2==0;
        }
        public static bool CheckOdd(int num)
        {
            return num % 2 != 0;
        }
        public static bool CheckPositive(int num)
        {
            return num>0;
        }


    }
}