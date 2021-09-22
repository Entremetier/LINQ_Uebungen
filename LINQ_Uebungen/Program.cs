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
                               where prod.ProductName.ToLower().Contains("o")
                               select prod;

            foreach (var item in produkteMitO)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var produkteMitO2 = product
                .Where(p => p.ProductName.ToLower().Contains("o"));


            foreach (var item in produkteMitO2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            //Anzahl Bestellungen je Kunde aus Deutschland
            var kundenUndBestellungen = from cust in customers
                                        where cust.Country == "Germany"
                                        select new { cust.CustomerID, cust.Orders.Count };

            foreach (var item in kundenUndBestellungen)
            {
                Console.WriteLine(item);
            }

            var kundenUndBestellungen2 = customers
                .Where(c => c.Country == "Germany")
                .Select(c => new { c.CustomerID, AnzahlBestellungen = c.Orders.Count });

            foreach (var item in kundenUndBestellungen2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            //Alle Bestellungen abfragen
            var alleBestellungen = from cust in customers
                                   from ord in cust.Orders
                                   select ord;

            foreach (var item in alleBestellungen)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var alleBestellungen2 = customers
                .SelectMany(c => c.Orders);

            foreach (var item in alleBestellungen2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();





            Console.ReadKey();
        }
    }
}
