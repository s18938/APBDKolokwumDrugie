using System;
using System.Collections.Generic;

namespace APBDKolokwumDrugie.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
