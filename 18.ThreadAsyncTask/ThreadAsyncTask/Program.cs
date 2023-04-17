namespace ThreadAsyncTask
{
    internal class Program
    {
        public static int Count=0;
        public static object blockObject=new object();
        //public static object blockObject2 = new object();

        static void Main(string[] args)
        {

            #region Thread Race condition
            //Thread thread1 = new Thread(Loop);
            //Thread thread2 = new Thread(Loop2);

            //thread1.Start();
            //thread2.Start();

            ////Console.WriteLine("ldsjfhsdgfjhdsfhksbdfskdjfsdfsdfsdfsdfdsfdsfdsfsdfsd");


            //thread1.Join();
            //thread2.Join();
            //Console.WriteLine(Count);
            ////Loop();
            ////Loop2(); 
            #endregion


            //Task task = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        Console.WriteLine($"1ci dovr ishleyir {i}");

            //    }
            //});
            //Task task2 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        Console.WriteLine($"2ci dovr{i}");

            //    }
            //});

            //task.Wait();
            //task2.Wait();
            //Console.ReadLine();
            //Console.WriteLine("Her shey bitdi");



           //var task =LoopTask();

           var task= Task.WhenAll(LoopTask(), LoopTask2());


            //Console.WriteLine(task.ContinueWith());


            Console.WriteLine("Kod bitdi");
            //Console.WriteLine(task.Result);

            
        }


        public static async Task<int> LoopTask()
        {

            int sum = 0;
            for (int i = 0; i < 100000; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            return sum;
           
        }
        public static async Task<int> LoopTask2()
        {

            int sum = 0;
            for (int i = 100; i < 200000; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            return sum;

        }

        public static void Loop()
        {
            Thread.Sleep(2000);

            for (int i = 0; i < 100000; i++)
            {

                Console.WriteLine($"1ci dovr ishleyir {i}");

                //lock (blockObject)
                //{
                   
                //        Count++;
                    
                   
                //}
               

            }
        }
        public static void Loop2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine($"2ci dovr{i}");



                //lock (blockObject)
                //    {
                //        Count--;
                //    }
                   
               
            }
        }
    }
}