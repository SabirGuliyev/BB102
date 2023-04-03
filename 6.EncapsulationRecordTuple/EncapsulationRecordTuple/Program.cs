using EncapsulationRecordTuple.Models;

namespace EncapsulationRecordTuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Encapsulation
            //User user = new User("Sabir", "Guliyev");
            //PersonClass person = new PersonClass("Yusif", "Aliyev");

            //user.PersonClass = person;

            
            //Console.WriteLine(user.PersonClass.Name);

            //Console.WriteLine(user.RegisteredAt.AddYears(10));


            //user.Username = "Salam";

            //user.Password = Console.ReadLine();

            //string name=Console.ReadLine();

            //user.Name = name;


            //Console.WriteLine(user.Username);


            //Console.WriteLine($"Name:{user.Name}\nSurname:{user.Surname}"); 
            #endregion


            #region Record
            //User user = new User("Sabir", "Guliyev");
            //User user2 = new User("Sabir", "Guliyev");
            ////Console.WriteLine(user==user2);
            //Console.WriteLine(user);
            //PersonClass person = new PersonClass("Fidan", "Baratli");
            //PersonClass person2 = person;
            //person2.Name = "Azade";
            //Console.WriteLine(person==person2);


            //PersonRecord personRecord = new PersonRecord("Yusif", "Aliyev");

            //PersonRecord personRecord2 = personRecord;

            //personRecord = personRecord with
            //{
            //    Name="Ismayil"
            //};
            //StudentRecord student = new StudentRecord("Yusif", "Aliyev");
            //Console.WriteLine(personRecord);


            //Console.WriteLine(personRecord == personRecord2);
            //Console.WriteLine(personRecord); 
            #endregion


            #region Tuple
            //string month = "Yanvar";
            //int day = 31;

            //(string Name, int Days) month = ("Yanvar", 31);
            //var month = Tuple.Create("Yanvar", 31);

            //month.Item1 = "Mart";
            //month.Name = "Fevral";
            //month.Days = 28;

            //Console.WriteLine(month);

            //int[] numbers = { 5, 1, 3, 4, 76 };

            //var maxMin=FindMaxMin(numbers,month);


            //Console.WriteLine(maxMin.Max); 
            #endregion


            Group group = new Group
            {
                Name="BB102"

            };

            Student student = new Student("Yusif", "Aliyev");

            group.AddStudent(student);

            //group.Students = new Student[0];
            Console.WriteLine(group.Students[0].Name);



        }
        //public static (int Max, int Min) FindMaxMin(int[] arr,(string ,int) month)
        //{
           
        //    return (arr.Max(), arr.Min());
        //}
    }
}