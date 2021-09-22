using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Uebungen
{
    public class Product
    {
        // Eigenschaften

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }

        // Konstruktor

        public Product(int productID, string productName, double unitPrice)
        {
            ProductID = productID;
            ProductName = productName;
            UnitPrice = unitPrice;
        }

        // Methoden

        public override string ToString()
        {
            return $"ProductID={ProductID}, ProductName={ProductName}, UnitPrice={UnitPrice:n}";
        }
    }
}
