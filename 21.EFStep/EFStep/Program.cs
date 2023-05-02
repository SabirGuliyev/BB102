using EFStep.DAL;
using EFStep.Models;

namespace EFStep
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AppDbContext dbContext = new AppDbContext();

            //ADD
            //Student student = new Student
            //{


            //    Surname = "Baratli",
            //    Name = "Fidan",
            //    Age = 21
            //};


            //dbContext.Students.Add(student);
            //dbContext.SaveChanges();


            //Student existed = dbContext.Students.Find(4);
            //existed.Name = "Ismayil3";
            //dbContext.SaveChanges();

            //Console.WriteLine(existed.Name+" "+existed.Surname);

            //if (existed != null)
            //{
            //    dbContext.Students.Remove(existed);
            //    dbContext.SaveChanges();
            //}


            List<Student> students = dbContext.Students.ToList();


            // foreach (var item in students)
            // {
            //     Console.WriteLine(item.Name);
            // }



            //List<Student> searchedStudents=dbContext.Students.Where(s=>s.Age>20).ToList();



            //foreach (var item in searchedStudents)
            //{
            //    Console.WriteLine(item.Name+" "+item.Age);
            //}



        }
    }
}