using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationRecordTuple.Models
{
    internal class User
    {
        private string _name;
        private string _surname;
        private string _username;
        private string _password = "12345678";
        private DateTime _registeredAt=DateTime.Now;

        //public PersonClass PersonClass;

        public DateTime RegisteredAt
        {
            get
            {
                return _registeredAt;
            }
           
        }
        public string Name 
        { 
            get 
            {
                return _name;
            }
            set
            {
                value = value.Trim();
                if (value.Length>=3 && value.Length<=25)
                {
                    _name = value;
                    //Console.WriteLine("Ad teyin edildi");
                }
                else
                {
                    //Console.WriteLine("Deyer yanlishdir");
                }
            }
               
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                value = value.Trim();
                if (value.Length >= 3 && value.Length <= 25)
                {
                    _surname = value;
                    //Console.WriteLine("Soyad teyin edildi");
                }
                else
                {
                    //Console.WriteLine("Deyer yanlishdir");
                }
            }

        }

        public string Username 
        { get
            {
                return _username;
            }
           
        }
        public string Password 
        { 
            set 
            { 

                _password = value;
            }
        }
        public User(string name, string surname)
        {
            Name = name;
            Surname = surname;

            _username = name+surname;
           
        }

        


        //public void SetName(string name)
        //{
        //    name=name.Trim();
        //    if (name.Length>=3&&name.Length<=25)
        //    {
        //        Name=name;
        //        Console.WriteLine("Ad teyin edildi");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Deyer yanlishdir");
        //    }
        //}
        //public string GetName()
        //{
        //    return Name;
        //}
    }
}
