using HplusSportAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HplusSportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _db;
        public ProductsController(ShopDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductQueryParameters queryParameters)

        {
            IQueryable<Product> products = _db.Products;

            if(queryParameters.MinPrice != null)
            {
                products = products.Where(
                    p => p.Price >= queryParameters.MinPrice);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(
                    p => p.Price <= queryParameters.MaxPrice);
            }

            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(
                    p=> p.Sku == queryParameters.Sku);
            }

            if(!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(
                  p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
            }

            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await products.ToArrayAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("isAvailable")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsInStock()
        {
            var product = await _db.Products.Where(u => u.IsAvailable).ToArrayAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllProducts),
                new { id = product.ProductId },
                product
            );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> ChangeProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(product).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Products.Any(p => p.ProductId == id))
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
             _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult> DeleteSeveralProducts([FromQuery] int [] ids)
        {
            var products = new List<Product>();
            foreach(var id in ids)
            {
                var product = await _db.Products.FindAsync(id);
                if(product == null)
                {
                    return NotFound();
                }
                products.Add(product);
                
            }
            _db.Products.RemoveRange(products);
            await _db.SaveChangesAsync();
            return Ok();
           
        }
    }
}
