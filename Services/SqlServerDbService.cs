﻿using APBDKolokwumDrugie.DTOs.Reqests;
using APBDKolokwumDrugie.DTOs.Response;
using APBDKolokwumDrugie.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKolokwumDrugie.Services
{
    public class SqlServerDbService : IDbService
    {
        private readonly ProbneKolAPBD2Context _context;
        public SqlServerDbService(ProbneKolAPBD2Context context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders()
        {
           return _context.Order.ToList();
        }

        public IEnumerable<Order> GetOrders(string LastName)
        {
            
                var ID = _context.Customer.Where(e => e.LastName.Equals(LastName)).FirstOrDefault().IdCustomer;
            if (ID.Equals(null))
            { 
                throw new Exception("nie ma klienta o podanym nazwisku");
            }

            var Result = _context.Order.ToList().Where(o => o.CustomerIdCustomer == ID);
            return Result;
            
           
        }

        public OrderResponse MakeOrder(int IdCustomer, OrderRequest Order)
        {
            try
            {
                int NewIdOrder = _context.Order.Max(e => e.IdOrder + 1);
                var z1 = new Order { IdOrder = NewIdOrder, DateIn = Order.DateIn, DateOut = Order.DateOut, Comments = Order.Comments, CustomerIdCustomer = IdCustomer };
                _context.Order.Add(z1);

                /*     foreach (OrderCandy OrdCan in Order.OrderCandy)
                     {

                         int NewIdCandy = _context.Candy.Where(e => e.IdCandy==OrdCan.CandyIdCandy).Select(e => e.IdCandy).First();
                         var ResultOrderCandy = new OrderCandy { OrderIdOrder = NewIdOrder, CandyIdCandy = NewIdCandy, Quantity = OrdCan.Quantity, Comments = OrdCan.Comments };
                         _context.OrderCandy.Add(ResultOrderCandy);

                     } */
                _context.SaveChanges();
                return new OrderResponse { IdOrder = NewIdOrder, DateIn = Order.DateIn, DateOut = Order.DateOut, Comments = Order.Comments, CustomerIdCustomer = IdCustomer };
            }
            catch (SqlException e)
            {
                throw;
            }
            
        }

        
    }
}
