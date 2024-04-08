using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapperMVC.Models;
using AutoMapperMVC.Models.DTOs;
using AutoMapperMVC.Models.ORM;
using FluentValidation;

namespace AutoMapperMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AutoMapperDbContext _context;
        private readonly IValidator<Customer> _customerValidator;
        private readonly IMapper _mapper;

        public CustomersController(AutoMapperDbContext context,IValidator<Customer> customerValidator, IMapper mapper)
        {
            _context = context;
            _customerValidator = customerValidator;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
			return _mapper.Map<List<CustomerDto>>(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return _mapper.Map<CustomerDto>(customer);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.Map<Customer>(customerDto)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDto customerDto)
        {
            _context.Customers.Add(_mapper.Map<Customer>(customerDto));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customerDto.Id }, customerDto);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
