using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKolokwumDrugie.DTOs.Response
{
    public class OrderResponse
    {
        public int IdOrder { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Comments { get; set; }
        public int EmployeeIdEmployee { get; set; }
        public int CustomerIdCustomer { get; set; }
    }
}
