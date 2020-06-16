using System;
using System.Collections.Generic;

namespace APBDKolokwumDrugie.Models
{
    public partial class OrderCandy
    {
        public int CandyIdCandy { get; set; }
        public int OrderIdOrder { get; set; }
        public int Quantity { get; set; }
        public string Comments { get; set; }

        public virtual Candy CandyIdCandyNavigation { get; set; }
        public virtual Order OrderIdOrderNavigation { get; set; }
    }
}
