using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klassenbibliothek;

namespace LINQ_Uebungen
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.CreateData(out List<Product> product, out List<Customer> customers);


            Console.WriteLine("Alle Kunden aus Deutschland:");

            //Kunden aus Deutschland ermitteln
            var customerGER = from c in customers
                              where c.Country == "Germany"
                              select new { ID = c.CustomerID, Firma = c.CompanyName };

            foreach (var item in customerGER)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var customerGer2 = customers
                .Where(c => c.Country == "Germany")
                //Liefert CustomerID und CompanyName als "anonymer Typ"
                .Select(c => new { c.CustomerID, Firma = c.CompanyName });

            //Da in customerGer2 ein anonymer Typ angewandt wird muss hier in der foreach var angegeben werden
            foreach (var item in customerGer2)
            {
                Console.WriteLine(item.CustomerID + " | " + item.Firma);
            }
            Console.WriteLine();


            //Produkte mit "o" ausgeben
            Console.WriteLine("Produkte mit \"o\":");
            var produkteMitO = from prod in product
                               where prod.ProductName.Contains("o") || prod.ProductName.Contains("O")
                               select prod;

            foreach (var item in produkteMitO)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var produkteMitO2 = product
                .Where(p => p.ProductName.Contains("o") || p.ProductName.Contains("O"));


            foreach (var item in produkteMitO2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            //

            Console.ReadKey();
        }
    }
}
