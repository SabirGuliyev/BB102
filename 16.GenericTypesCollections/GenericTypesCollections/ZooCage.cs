using GenericTypesCollections.Animals;
using GenericTypesCollections.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesCollections
{
    internal class ZooCage<T,U> where T:Animal
                                where U:Food
    {
        public string CageNO;

        public T[] arr=new T[0];

        public U Food { get; set; }


        

        public ZooCage(U food)
        {
            Food=food;
        }
        public void Add(T animal)
        {
            Array.Resize(ref arr, arr.Length+1);
            arr[arr.Length-1]=animal;
        }

        public void ShowAnimals()
        {
            foreach (T animal in arr)
            {
                Console.WriteLine(animal.Name+" "+animal.AvgLifetime);
            }
        }
        public void ShowFood()
        {
            Console.WriteLine(Food.TypeName);
        }

        //public T Search()
        //{
        //    return arr[0];
        //}

    }
}
