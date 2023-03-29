namespace ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Power(3);

            //int a = 5;
            //int b = a;
            //b += 5;
            //Console.WriteLine(a);
            //int[] arr = { 1, 2, 3 };
            ////int[] copy = arr;
            //int[] arr2 = {1,2,3 };




            //copy[0] = 200;

            //Console.WriteLine(arr==arr2);


            //foreach (int num in arr)
            //{
            //    Console.WriteLine(num);
            //}

            //int number = 10;
            //ChangeValue(number);
            //Console.WriteLine(number);

            //int[] arr = { 1, 2, 3 };
            //ChangeIndex(arr);

            //foreach (int i in arr)
            //{
            //    Console.WriteLine(i);
            //}

            //ref ve out
            int a = 5;
            int b = 5;  
            ChangeValue(ref a,ref b);

            //Console.WriteLine(a+" "+b);

            int[] numbers = { 1, 2, 3, 4, 5 };

            //Array.Resize(ref numbers, numbers.Length + 1);
            //numbers[numbers.Length-1]=20;

            //Array.Resize(ref numbers, numbers.Length-1);
            //DeleteLastIndex(ref numbers);

            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            //ArrResize(ref numbers, 100);

            //foreach (var item in numbers)
            //{
            //    Console.WriteLine(item);
            //}

            int number=20;

            AssignValue(ref number);
            //Console.WriteLine(number);

            Console.WriteLine("Eded daxil edin:");
            //string str=Console.ReadLine();
            //int num;
            //bool result=int.TryParse(str,out num);
           int num =int.Parse(Console.ReadLine());
            //Console.WriteLine(result);
            Console.WriteLine(num);
            

        }
        public static void AssignValue(ref int num)
        {
            num += 100;
        } 
        public static void ArrResize(ref int[] arr,int num)
        {
            int[] copy=new int[arr.Length+1];

            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
            }
            copy[copy.Length-1] = num;

            arr = copy;
        }
        public static void DeleteLastIndex(ref int[] arr)
        {
            int[] copy = new int[arr.Length - 1];

            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = arr[i];
            }

            arr = copy;
        }
        public static void ChangeIndex(int[] nums)
        {
            nums = new int[0];
            nums[0] = 200;
        }
        public static void ChangeValue(ref int num, ref int num2)
        {
            num += 5;
            num2 += 100;
           
          
        }




        //public static void Power(int num,int power = 2)
        //{
        //    int save = num;
        //    for (int i = 1; i < power; i++)
        //    {
        //        save *= num;
        //    }
        //    Console.WriteLine(save);
        //}
    }
}