using StaticExtensionStruct.Models;

namespace StaticExtensionStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region Static
            //Person.GetInfo();




            //Person person = new Person { Name = "Azade" };
            //Person person2 = new Person { Name = "Yusif" };
            //Person person3 = new Person { Name = "Fidan" };

            //Person.AddPerson(person);
            //Person.AddPerson(person2); 
            //Person.AddPerson(person3);


            //Person.ShowPeople();
            //Console.WriteLine("--------------------------");

            //Person.Remove();
            //Person.ShowPeople();
            //Person.Search("aza");

            //Person.Search("i");

            //person.GetInfo();
            //person.GetInfo();
            //Helper.WifiPass = "sabir";
            //Console.WriteLine(Helper.WifiPass);


            //Console.WriteLine(Helper.Capitalize(Console.ReadLine()));


            //Console.WriteLine(Math.Pow(2, 10));


            //string word = "Salam";






            //Person person3 = new Person ("Fidan");
            ////person3.ExCapitalizeStu();
            //person3.Name.ExCapitalize();

            //Student student = new Student("bb102", 95);
            ////student.ExCapitalizeStu();

            //student.Group.ExCapitalize ();


            #endregion

            //PointClass pclass=new PointClass();
            //pclass.X = 5;
            //Console.WriteLine(pclass.X);
            //PointStruct pstruct=new PointStruct();
            //pstruct.X = 5;
            //Console.WriteLine(pstruct.X);

            int a = 5;
            PointClass pclass;
       
            PointStruct pstruct;






            Console.WriteLine();

        }
        public static void Test(PointStruct point)
        {

        }
    }
    #region Static examples
    internal class Person
    {
        public static Person[] People = new Person[0];
        public static int HistoryYears = 200;
        public string Name { get; set; }

        public Person(string name)
        {
            Name = Helper.Capitalize(name);
            Name = name.ExCapitalize();
        }
        static Person()
        {
            Console.WriteLine("Static ctor");
        }
        public void GetInfo()
        {
            Console.WriteLine(Name);

        }
        public static void StaticGetInfo()
        {

            Console.WriteLine(HistoryYears);
        }
        public static void AddPerson(Person person)
        {
            Array.Resize(ref People, People.Length + 1);
            People[People.Length - 1] = person;
        }
        public static void ShowPeople()
        {
            foreach (Person person in People)
            {
                Console.WriteLine(person.Name);
            }
        }
        public static void Search(string name)
        {
            foreach (Person person in People)
            {
                if (person.Name.ToLower().Contains(name.ToLower()))
                {
                    person.GetInfo();
                }
            }
        }
        public static void Remove()
        {
            Array.Resize(ref People, People.Length - 1);
        }


    } 
    #endregion
}