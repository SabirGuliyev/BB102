using AccessModifiers.Models;
using Education;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Field Array
            //Group group = new Group("BB102");

            //var student = new Student("Yusif");
            //Student student2 = new Student("Fidan");
            //Student student3 = new Student("Azade");
            //Student student4 = new Student("Punhan");

            //group.AddStudent(student);
            //group.AddStudent(student2);
            //group.AddStudent(student3);
            //group.AddStudent(student4);

            //Console.WriteLine("Uzunluq-------------------------- ");
            //Console.WriteLine(group.Students.Length);
            //Console.WriteLine("Telebeler-------------------------");


            //foreach (var stud in group.Students)
            //{
            //    Console.WriteLine(stud.Name);
            //} 
            #endregion

            Person person = new Person();

            person.Salary = 123123;
            Employee employee = new Employee();

            //person.Salary = 800;

        }
    }
}