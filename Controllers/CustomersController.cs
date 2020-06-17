using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDKolokwumDrugie.DTOs.Reqests;
using APBDKolokwumDrugie.Models;
using APBDKolokwumDrugie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Data.SqlClient;

namespace APBDKolokwumDrugie.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class CustomersController : ControllerBase
    {
       
        private readonly IDbService _service;
        public CustomersController( IDbService service)
        {
            
            _service = service;
        }
        [HttpPost("{IdCustomer}/orders")]
        public IActionResult MakeOrder(int IdCustomer, [FromBody] OrderRequest Order)
        {
            try
            {            
               
                return  Ok(_service.MakeOrder(IdCustomer, Order));
            }
            catch (SqlException e)
            {
                return BadRequest();
            }
          
        }
        }
}
