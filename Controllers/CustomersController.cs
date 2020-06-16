using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDKolokwumDrugie.Models;
using APBDKolokwumDrugie.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwumDrugie.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class CustomersController : ControllerBase
    {
       
        private readonly IDbService _service;
        public CustomersController( SqlServerDbService service)
        {
            
            _service = service;
        }
        [HttpPost("{IdCustomer}/orders")]
        public IActionResult MakeOrder(int IdCustomer, [FromBody] Order Order)
        {
            try
            {            
                _service.MakeOrder(IdCustomer, Order);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
        }
}
