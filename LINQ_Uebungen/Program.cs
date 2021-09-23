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



            //Anzahl der Produkte
            var anzahl = (from n in product
                          select n)
                          .Count();
            Console.WriteLine("Anzahl aller Produkte (Abfragesyntax): " + anzahl);

            Console.WriteLine("Anzahl aller Produkte (Methodensyntax): " + product.Count());
            Console.WriteLine();



            //Anzahl der Produkte mit x
            var anzahlMitX = (from n in product
                              where n.ProductName.ToLower().Contains("x")
                              select n)
                              .Count();
            Console.WriteLine("Anzahl aller Produkte (Abfragesyntax): " + anzahlMitX);

            Console.WriteLine("Anzahl aller Produkte (Methodensyntax): " + product.Where(n => n.ProductName.ToLower().Contains("x")).Count());
            Console.WriteLine();


            //Das teuerste und billigste Produkt ausgeben

            var billigstesProd = (from p in product
                                  select p.UnitPrice)
                                  .Min();

            Console.WriteLine("Billigstes Produkt (Abfragesyntax): " + billigstesProd);
            Console.WriteLine("Billigstes Produkt (Methodensyntax): " + product.Min(p => p.UnitPrice));
            Console.WriteLine();

            var teuerstesProd = (from p in product
                                 select p.UnitPrice)
                                  .Max();

            Console.WriteLine("Teuerstes Produkt (Abfragesyntax): " + teuerstesProd);
            Console.WriteLine("Teuerstes Produkt (Methodensyntax): " + product.Max(p => p.UnitPrice));


            //Durchschnittspreis aller Produkte
            var averagePrice = (from p in product
                                select p.UnitPrice)
                               .Average();

            Console.WriteLine("Durchschnittspreis aller Produkte (Abfragesyntax): " + averagePrice);
            Console.WriteLine("Durchschnittspreis aller Produkte (Methodensyntax): " + product.Average(p => p.UnitPrice));


            //Erstes Produkt das mehr als 50€ kostet
            var prodMehr50 = (from n in product
                              where n.UnitPrice > 50
                              select n)
                              .FirstOrDefault();

            Console.WriteLine("\nErstes Produkt das mehr als 50€ kostet (Abfragesyntax): " + prodMehr50);


            //Erstes Produkt das mehr als 50€ kostet
            var prodMehr40 = (from n in product
                              where n.UnitPrice > 40
                              select n)
                              .FirstOrDefault();

            Console.WriteLine("\nErstes Produkt das mehr als 50€ kostet (Abfragesyntax):\n" + prodMehr40);


            Console.WriteLine("\nErstes Produkt das mehr als 50€ kostet (Methodensyntax): "
                + product.FirstOrDefault(p => p.UnitPrice > 50));

            Console.WriteLine("\nErstes Produkt das mehr als 40€ kostet (Methodensyntax):\n" +
                product.FirstOrDefault(p => p.UnitPrice > 40));


            //Einziges Produkt das mehr als 50€ kostet
            var prodMehr50A = (from n in product
                               where n.UnitPrice > 50
                               select n)
                               .SingleOrDefault();
            Console.WriteLine("\nEinziges Produkt das mehr als 50€ kostet (Abfragesyntax): " + prodMehr50A);


            //Einzige Product das mehr als 45€ kostet
            var prodMehr45A = (from n in product
                               where n.UnitPrice > 45
                               select n)
                               .SingleOrDefault();

            Console.WriteLine("\nEinziges Produkt das mehr als 45€ kostet: (Abfragesyntax)\n" + prodMehr45A);

            Console.WriteLine("\nEinziges Produkt das mehr als 50€ kostet (Methodensyntax):\n"
                + product.SingleOrDefault(p => p.UnitPrice > 50));

            Console.WriteLine("\nEinziges Produkt das mehr als 45€ kostet (Methodensyntax):\n"
                + product.SingleOrDefault(p => p.UnitPrice > 45));


            //Exception für das Produkt das mehr als 40€ kostet
            //var prodMehr40A = (from n in product
            //                   where n.UnitPrice > 40
            //                   select n)
            //                   .SingleOrDefault();

            //Console.WriteLine("\nEinziges Produkt das mehr als 40€ kostet:\n" + prodMehr40A);

            //Console.WriteLine("\nEinziges Produkt das mehr als 40€ kostet (Methodensyntax):\n"
            //   + product.SingleOrDefault(p => p.UnitPrice > 40));


            //Liste mit Großbuchstaben
            var liste = (from p in product
                         select new { ID = p.ProductID, ProductName = p.ProductName.ToUpper(), p.UnitPrice })
                         .ToList();

            // ODER aber nicht der Standard (besser den anonymen Typen verwenden)

            List<Product> prodListe = (from p in product
                         select new Product( p.ProductID, p.ProductName.ToUpper(), p.UnitPrice ))
                         .ToList();

            liste.Add(new { ID = 57, ProductName = "Ravioli Angelo", UnitPrice = 19.50 });
            liste.Add(new { ID = 75, ProductName = "Rhönbräu Klosterbier", UnitPrice = 7.75 });

            Console.WriteLine("Liste (Abfragesyntax):");
            foreach (var item in liste)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var liste2 = product
                .Select(p => new { ID = p.ProductID, ProductName = p.ProductName.ToUpper(), p.UnitPrice }).ToList();

            liste2.Add(new { ID = 57, ProductName = "Ravioli Angelo", UnitPrice = 19.50 });
            liste2.Add(new { ID = 75, ProductName = "Rhönbräu Klosterbier", UnitPrice = 7.75 });

            Console.WriteLine("Liste (Methodensyntax):");
            foreach (var item in liste2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();





            Console.ReadKey();
        }
    }
}
