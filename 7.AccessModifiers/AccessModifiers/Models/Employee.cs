using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Models
{
    internal class Employee:Person
    {
        public string Company;
        public Employee()
        {
            //Salary
            Salary2 = 23234234;
        }

        //public void GivePromotion()
        //{
        //    Salary += 200;
        //}
    }
}
