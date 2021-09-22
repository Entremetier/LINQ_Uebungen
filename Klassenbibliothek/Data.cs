using LINQ_Uebungen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassenbibliothek
{
    public class Data
    {
        public static void CreateData(out List<Product> products, out List<Customer> customers)
        {
            // Products

            Product p1 = new Product(31, "Gorgonzola Telino", 12.5);
            Product p2 = new Product(52, "Filo Mix", 7.0);
            Product p3 = new Product(63, "Vegie-spread", 43.9);
            Product p4 = new Product(48, "Chocolade", 12.7);
            Product p5 = new Product(43, "Ipoh Coffee", 46.0);
            Product p6 = new Product(37, "Gravad lax", 26.0);

            products = new List<Product> { p1, p2, p3, p4, p5, p6 };

            //Orders

            List<Order> orderALFKI = new List<Order>
            {
            new Order (10643, DateTime.Parse("25.08.1997"), "Germany", 31),
            new Order (10692, DateTime.Parse("03.10.1997"), "Germany", 63),
            };

            List<Order> orderBERGS = new List<Order>
            {
            new Order (10278, DateTime.Parse("12.08.1996"), "Sweden", 48),
            new Order (10280, DateTime.Parse("14.08.1996"), "Sweden", 52),
            new Order (10384, DateTime.Parse("16.12.1996"), "Sweden", 48),
            };

            List<Order> orderDUMON = new List<Order>
            {
            new Order (10311, DateTime.Parse("20.09.1996"), "France", 37),
            new Order (10609, DateTime.Parse("24.07.1997"), "France", 31),
            new Order (10683, DateTime.Parse("26.09.1997"), "France", 43),
            };

            List<Order> orderLEHMS = new List<Order>
            {
            new Order (10279, DateTime.Parse("13.08.1996"), "Germany", 37),
            new Order (10284, DateTime.Parse("19.08.1996"), "Germany", 43),
            new Order (10343, DateTime.Parse("31.10.1996"), "Germany", 43),
            new Order (10702, DateTime.Parse("13.10.1997"), "Germany", 48),
            };

            //Customers
            customers = new List<Customer>
            {
            new Customer ("ALFKI", "Alfreds Futterkiste", "Germany",  orderALFKI),
            new Customer ("BERGS", "Berglunds snabbköp", "Sweden", orderBERGS),
            new Customer ("DUMON", "Du monde entier", "France", orderDUMON),
            new Customer ("LEHMS", "Lehmanns Marktstand", "Germany", orderLEHMS),
            };
        }
    }
}
