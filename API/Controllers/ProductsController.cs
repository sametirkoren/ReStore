using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public ActionResult<List<Product>> GetProducts()
        {
            var products = _storeContext.Products.ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]

        public ActionResult<Product> GetProduct(int id)
        {
            return _storeContext.Products.Find(id);
        }

    }
}
