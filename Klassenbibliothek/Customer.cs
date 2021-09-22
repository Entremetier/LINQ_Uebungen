using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Uebungen
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }

        // Konstruktor

        public Customer(string customerID, string companyName, string country, List<Order> orders)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            Country = country;
            Orders = new List<Order>(orders);
        }

        // Methoden

        public override string ToString()
        {
            return $"CustomerID={CustomerID}, CompanyName={CompanyName}, Country={Country}";
        }
    }
}
