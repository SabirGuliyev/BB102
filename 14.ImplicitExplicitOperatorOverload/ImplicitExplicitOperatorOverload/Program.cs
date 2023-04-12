using ImplicitExplicitOperatorOverload.Models;

namespace ImplicitExplicitOperatorOverload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Manat manat = new Manat(340);
            //Dollar dEx = (Dollar)manat;
            //Dollar d = manat;
            //Console.WriteLine(d.USD);

            //Dollar dollar = new Dollar(250);
            //Manat mEx = (Manat)dollar;
            //Manat m = dollar;


            //Manat m2 = new Manat(dollar.USD * 1.68m);


            //Console.WriteLine(m.AZN);








          


            Manat manat = new Manat(200);
            Manat manat2 = new Manat(100);

            manat = manat + manat2;
            //Console.WriteLine(manat==200);
            Console.WriteLine(manat.AZN);


        }
    }
}