using APBDKolokwumDrugie.DTOs.Reqests;
using APBDKolokwumDrugie.DTOs.Response;
using APBDKolokwumDrugie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKolokwumDrugie.Services
{
   public interface IDbService
    {
        public IEnumerable<Order> GetOrders();
        public IEnumerable<Order> GetOrders(string LastName);
        public OrderResponse MakeOrder(int IdCustomer, OrderRequest Order);
    }
}
