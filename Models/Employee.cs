using System;
using System.Collections.Generic;

namespace APBDKolokwumDrugie.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Order = new HashSet<Order>();
        }

        public int IdEmployee { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
