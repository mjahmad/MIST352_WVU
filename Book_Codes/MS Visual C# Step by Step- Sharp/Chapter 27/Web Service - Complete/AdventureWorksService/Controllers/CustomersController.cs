using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorksService.Models;

namespace AdventureWorksService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers(int offset, int count)
        {
            if (offset < 0 || count < 0)
            {
                return BadRequest();
            }

            return await _context.Customers.
                OrderBy(r => r.CustomerID).
                Skip(offset).
                Take(count).ToListAsync();
        }

        // GET: api/Customes/find
        [HttpGet("find")]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> FindCustomers(
            string title = "%", string firstName = "%", string lastName = "%",
            string email = "%", string phone = "%")
        {
            var query = from c in _context.Customers
                        where EF.Functions.Like(c.Title, title) &&
                              EF.Functions.Like(c.FirstName, firstName) &&
                              EF.Functions.Like(c.LastName, lastName) &&
                              EF.Functions.Like(c.EmailAddress, email) &&
                              EF.Functions.Like(c.Phone, phone)
                        select c;

            return await query.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerModel(int id)
        {
            var customerModel = await _context.Customers.FindAsync(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            return customerModel;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerModel(int id, CustomerModel customerModel)
        {
            if (id != customerModel.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerModel(CustomerModel customerModel)
        {
            _context.Customers.Add(customerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerModel", new { id = customerModel.CustomerID }, customerModel);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerModel(int id)
        {
            var customerModel = await _context.Customers.FindAsync(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerModelExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
