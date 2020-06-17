using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKolokwumDrugie.DTOs.Reqests
{
    public class OrderRequest
    {
        
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Comments { get; set; }
        public int EmployeeIdEmployee { get; set; }
        
    }
}
