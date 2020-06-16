using System;
using System.Collections.Generic;

namespace APBDKolokwumDrugie.Models
{
    public partial class Candy
    {
        public Candy()
        {
            OrderCandy = new HashSet<OrderCandy>();
        }

        public int IdCandy { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public virtual ICollection<OrderCandy> OrderCandy { get; set; }
    }
}
