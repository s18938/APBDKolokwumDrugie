using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDKolokwumDrugie.Models;
using APBDKolokwumDrugie.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwumDrugie.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       
        private readonly IDbService _service;
        public OrdersController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{LastName}")]
        public IActionResult GetOrders(string LastName)
        {          
            return Ok(_service.GetOrders(LastName));
        }

        [HttpGet]
        public IActionResult GetOrders()
        {           
                return Ok(_service.GetOrders());
        }    
    }
}