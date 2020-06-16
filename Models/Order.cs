using System;
using System.Collections.Generic;

namespace APBDKolokwumDrugie.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderCandy = new HashSet<OrderCandy>();
        }

        public int IdOrder { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Comments { get; set; }
        public int EmployeeIdEmployee { get; set; }
        public int CustomerIdCustomer { get; set; }

        public virtual Customer CustomerIdCustomerNavigation { get; set; }
        public virtual Employee EmployeeIdEmployeeNavigation { get; set; }
        public virtual ICollection<OrderCandy> OrderCandy { get; set; }
    }
}
