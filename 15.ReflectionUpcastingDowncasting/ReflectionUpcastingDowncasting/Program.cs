using ReflectionUpcastingDowncasting.Models;
using System.Reflection;

namespace ReflectionUpcastingDowncasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Reflection
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Type[] types=assembly.GetTypes();
            //FieldInfo
            //MethodInfo
            //FieldInfo field = typeof(Student).GetField("StudentName");
            //foreach (Type type in types)
            //{
            //    Console.WriteLine("-----------------------------");
            //    Console.WriteLine("Type:" + type.Name);

            //    foreach (var member in type.)
            //    {
            //        Console.WriteLine(member);
            //    }

            //}

            //Teacher teacher = new Teacher("Sabir");
            //Teacher teacher2 = new Teacher("Resul");

            //Type type = teacher.GetType();

            //FieldInfo privField = type.GetField("TeacherName", BindingFlags.NonPublic | BindingFlags.Instance);

            //privField.SetValue(teacher2,"Elnur");

            //Console.WriteLine(privField.GetValue(teacher2));

            //Type type2=typeof(Teacher);




            //var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            //foreach (FieldInfo field in fields)
            //{
            //    Console.WriteLine(field.Name);
            //}
            //Console.WriteLine(type2.Name);


            //Teacher teacher = new Teacher("Sabir");


            //Type type = teacher.GetType();

            //FieldInfo field=type.GetField("Id",BindingFlags.NonPublic| BindingFlags.Instance);

            //field.SetValue(teacher, "45678");

            //Console.WriteLine(field.GetValue(teacher)); 
            #endregion


            #region Upcasting,boxing - Dowcasting,unboxing
            Dog dog = new Dog { AvgLifeTime = 8, Name = "Bobik" }; //implicit
            Eagle eagle = new Eagle { AvgLifeTime = 12 };

            Animal[] zoo = {dog,eagle};
            foreach (Animal a in zoo)
            {
              var type=a.GetType();
                foreach (FieldInfo item in type.GetFields(BindingFlags.Public|BindingFlags.Instance))
                {
                    Console.WriteLine(item.GetValue(a));
                    
                }

            }

            //Dog dog4 = (Dog)zoo[0];


            //foreach (var anim in zoo)
            //{
            //    var down = anim as Dog;
            //if (!(down is null))
            //{
            //    Console.WriteLine(down.Name);
            //}

            //var down = (Dog)anim;  // 1.Downcast

            //if (anim is Dog down)
            //{
            //    //1. var down = (Dog)anim; Explicit
            //    //2. var down = anim as Dog;
            //3. Is ile cast etmek olur amma cast operatoru deyil!!!!!!!!!

            //    Console.WriteLine(down.Name);

            //}



            //if (anim is Eagle)
            //{
            //    var down = (Eagle)anim;
            //    down.Fly();
            //}


            //a.MakeSound();
            //Console.WriteLine(a.AvgLifeTime);
            //}

            //Dog down = (Dog)dog;

            //Console.WriteLine(down.AvgLifeTime+" "+down.Name); 
            #endregion



        }
    }
}