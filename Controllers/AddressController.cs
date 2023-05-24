using ClientesApi.DataModel;
using ClientesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpDelete("delete/{addressId}")]

        public async Task<ActionResult> Delete(int addressId)
        {
            var affectedRows = await _context.Addresses.Where(a => a.AddressId == addressId).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }



        [HttpPut]
        public ActionResult<Address> Update([FromBody] Address address)
        {
            _context.Update(address);
            _context.SaveChanges();

            return Ok(address);
        }




    }
}
