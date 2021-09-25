using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5.Entities.JoinEntities
{
    public class CustomerNamesUpperLower
    {
        public string CompanyNameLower { get; set; }
        public string CompanyNameUpper { get; set; }
        public string ContactNameLower { get; set; }
        public string ContactNameUpper { get; set; }
    }

    public class CustomerAndRegionJoin
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }

    public class CustomerOrdersQuantity
    {
        public Customers Customer { get; set; }
        public int OrdersQuantity { get; set; }
    }

}
