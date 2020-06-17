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
        public IActionResult GetOrders([FromRoute]string LastName)
        {
           
            try
            {
                return Ok(_service.GetOrders(LastName));
            }catch(Exception e)
            {
                return NotFound("nie ma zamówienia dla klienta o podanym nazwisku");
            }
        }

        [HttpGet]
        public IActionResult GetOrders()
        {          
                return Ok(_service.GetOrders());
           
        }    
    }
}