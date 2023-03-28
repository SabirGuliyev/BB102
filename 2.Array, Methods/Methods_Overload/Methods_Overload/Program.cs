namespace Methods_Overload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Salam");
            //return;
            //Console.WriteLine("Dunya");

            //int price = 90;
            //int discount = price * 10 / 100;
            //Console.WriteLine(discount);

            //int price2 = 80;
            //int discount2 = price2 * 20 / 100;
            //Console.WriteLine(discount2);

            //int discount=GetDiscount(90, 10);
            //discount += 20;

            //Console.WriteLine(discount);


            //Console.WriteLine(GetFullName());


            //int[] numbers = { 1, 5, 7, 8 };
            //int[] numbers2 = { 1, 2, 3 };    

            //int result=GetSum(numbers);

            //Console.WriteLine(GetSum(numbers2));

            //Console.WriteLine(result);
            //string[] result = GetWords("Salam", "Gencler", "Necesiz");


            //GetWords("Salam", "Gencler", "Necesiz","Yaxshi","Siz","Necesiz");
            //DetermineFullname("Punhan");
            //OddOrEven(0);


            //Sum(5, 10);
            //Sum(5, 10, 15);
            //Sum(3.2, 5);
            //Sum(4d, 3d);

            //Sum(5, 6);
            //CheckCollection(1,4,5,6);
            bool result=
            CheckBool(CheckOddOrEven(3));

        }
        public static void CheckCollection(params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (CheckOddOrEven(numbers[i]))
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
        public static bool CheckOddOrEven(int num)
        {
            bool result = false;
            if (num==0)
            {
                return result;
            }

            if (num%2==0)
            {
                result = true;
            }

            return result;
        }
        public static void CheckBool(bool result)
        {
            Console.WriteLine(result);
        }
        //public static void Sum(int num, int num2)
        //{
        //    Console.WriteLine("2 parametirli int ");
        //}
        //public static int Sum(int num2)
        //{
        //    return 12;
        //}

        //public static void Sum(int num2,double num3)
        //{
        //    Console.WriteLine("int evvelde olan");
        //}
        //public static void Sum(double num3, int num2)
        //{
        //    Console.WriteLine("double evvelde olan");
        //}


        //public static void Sum(int num2)
        //{
        //    Console.WriteLine("error veren");
        //}
        //public static void Sum(decimal num2)
        //{
        //    Console.WriteLine("decimal olan veren");
        //}
        //public static void Sum(int num,int num2)
        //{
        //    Console.WriteLine("2 parametirli int ");
        //}

        //public static void Sum(int num, int num2,int num3=5,int num4=6)
        //{
        //    Console.WriteLine("4 parametrli int");
        //}
        //public static void Sum(params int[] numvbers)
        //{
        //    Console.WriteLine("Paramla olan");
        //}
        //public static void Sum(double num,double num2)
        //{
        //    Console.WriteLine(num/num2);
        //}



        //public static void OddOrEven(int num)
        //{
        //    if (num<=0)
        //    {
        //        Console.WriteLine("Ne cut ne tek");
        //        return;
        //    }

        //    if (num%2==0)
        //    {
        //        Console.WriteLine("Cutdur");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Tekdir");
        //    }

        //}

        //public static void DetermineFullname(string name,params string[] words)
        //{
        //    Console.WriteLine(words.Length);
        //}
        //public static void DetermineFullname(string name, params string[] words)
        //{
        //    Console.WriteLine(name + " ");
        //}
        //public static void GetWords(params string[] word)
        //{
        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        Console.WriteLine(word[i]);
        //    }
        //  ;
        //}

        //public static void GetSum(params int[] numbers)
        //{
        //    int sum = 0;    
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        sum+=numbers[i];
        //    }

        //    Console.WriteLine(sum);
        //}
        //public static int GetSum(int[] arr)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        sum += arr[i];
        //    }

        //    return sum;
        //}

        //public static int GetDiscount(int price, int percent)
        //{
        //    int result = price * percent / 100;
        //    return result;
        //}


        //public static string GetFullName()
        //{
        //    Console.WriteLine("Please enter your name:");
        //    string name=Console.ReadLine();
        //    Console.WriteLine("Please enter your surname:");
        //    string surname=Console.ReadLine();

        //    string result= name + " " + surname;
        //    return result;
        //}
    }
}