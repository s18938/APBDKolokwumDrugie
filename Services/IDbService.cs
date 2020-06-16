using APBDKolokwumDrugie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKolokwumDrugie.Services
{
    interface IDbService
    {
        public IEnumerable<Order> GetOrders();
        public IEnumerable<Order> GetOrders(string LastName);
        public void MakeOrder(int IdCustomer, Order Order);
    }
}
