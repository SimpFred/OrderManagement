using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _context.Orders
          .Include(o => o.Customer)
          .Include(o => o.Products)
          .ToListAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _context.Orders
     .Include(o => o.Customer)
     .Include(o => o.Products)
     .FirstOrDefaultAsync(o => o.Id == id);
                if (order == null) return NotFound();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                // Check if the customer exists in the database
                var customer = await _context.Customers.FindAsync(order.CustomerId);
                if (customer == null)
                {
                    return BadRequest("Invalid customer ID.");
                }

                // Set the Customer navigation property to the existing customer
                order.Customer = customer;

                // Create new product entries for the order
                var orderProducts = new List<Product>();
                foreach (var product in order.Products)
                {
                    var newProduct = new Product
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = product.Quantity
                    };
                    orderProducts.Add(newProduct);
                }

                // Set the products in the order
                order.Products = orderProducts;

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}

