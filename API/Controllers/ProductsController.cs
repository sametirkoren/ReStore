using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        public ProductsController(StoreContext context)
        {
            _storeContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =  await _storeContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);

            if(product == null) return NotFound();

            return product;
        }

    }
}
