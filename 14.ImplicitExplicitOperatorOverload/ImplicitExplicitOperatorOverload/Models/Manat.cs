using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitExplicitOperatorOverload.Models
{
    internal class Manat
    {
        public decimal AZN { get; set; }
        public Manat(decimal aZN)
        {
            AZN = aZN;

        }



        public static bool operator ==(Manat m, Manat m2)
        {

            return m.AZN == m2.AZN ;
        }
        public static bool operator ==(Manat m, decimal digit)
        {

            return m.AZN ==digit;
        }
        public static bool operator !=(Manat m, Manat m2)
        {
            return !(m.AZN == m2.AZN);
        }
        public static bool operator !=(Manat m, decimal digit)
        {
            return !(m.AZN == digit);
        }

        public static bool operator >=(Manat m,Manat m2)
        {
            return m.AZN>= m2.AZN;
        }
        public static bool operator <=(Manat m, Manat m2)
        {
            return m.AZN <= m2.AZN;
        }
        public static Manat operator +(Manat m, Manat m2)
        {
            return new Manat(m.AZN+m2.AZN);
        }


        public static implicit operator Manat(Dollar dollar)
        {
            return new Manat(dollar.USD * 1.7m);
        }
        //public static explicit operator Manat(Dollar dollar)
        //{
        //    return new Manat(dollar.USD * 1.7m);
        //}


    }
    internal class Dollar
    {
        public decimal USD { get; set; }
        public Dollar(decimal uSD)
        {
            USD = uSD;
        }







        public static implicit operator Dollar(Manat manat)
        {
            return new Dollar(manat.AZN / 1.7m);
        }
        //public static explicit operator Dollar(Manat manat)
        //{
        //    return new Dollar(manat.AZN / 1.7m);
        //}
    }
}
