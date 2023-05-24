using ClientesApi.DataModel;
using ClientesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private CustomerdbContext _context;

        public AddressController(CustomerdbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Customer>> GetCustomers(int id)
        {
            var addresses = _context.Addresses.Where(t => t.CustomerId == id)
                                                    .ToList();
            return Ok(addresses);
        }




    }
}
