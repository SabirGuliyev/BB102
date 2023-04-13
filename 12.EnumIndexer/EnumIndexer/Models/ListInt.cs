using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumIndexer.Models
{
    internal class CustomList<T>
    {
        private T[] _arr;
        
        public int Length { 
            get
            {
             return _arr.Length;
            } 
        }
        public T this[int index] 
        {
            get 
            { 
                if (index < _arr.Length)
                {
                    return _arr[index];
                }
                else
                {
                    Console.WriteLine("Max index");
                    return _arr[_arr.Length - 1];
                }
               
            }
            set
            {
                if (index<_arr.Length)
                {
                    _arr[index] = value;
                }
               
            }
        }


        public CustomList()
        {
            _arr = new T[0];
        }
        public CustomList(int length)
        {
            _arr = new T[length];
        }
        public CustomList(params T[] numbers)
        {
            _arr = new T[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                _arr[i] = numbers[i];
            }
        }
        public void Add(T num)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
            _arr[Length-1] = num;
        }
    }
}
