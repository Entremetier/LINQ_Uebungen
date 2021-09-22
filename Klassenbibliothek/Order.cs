using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Uebungen
{
    public class Order
    {
        // Eigenschaften

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCountry { get; set; }
        public int ProductID { get; set; }

        // Konstruktor

        public Order(int orderID, DateTime orderDate, string shipCountry, int productID)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            ShipCountry = shipCountry;
            ProductID = productID;
        }

        // Methoden

        public override string ToString()
        {
            return $"OrderID={OrderID}, OrderDate={OrderDate.ToShortDateString()}, ShipCountry={ShipCountry}, ProductID={ProductID}";
        }
    }
}
