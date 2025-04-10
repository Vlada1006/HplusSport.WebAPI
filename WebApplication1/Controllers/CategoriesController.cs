using HplusSportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HplusSportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopDbContext _db;
        public CategoriesController(ShopDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery]QueryParameters queryParameters)
        {
            IQueryable<Category> categories = _db.Categories;
            categories = categories.
                Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await categories.ToArrayAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(u => u.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        [Route("{id}/productsRelated")]
        public async Task<ActionResult> GetProductsByCategoryId(int id)
        {
            var category = await _db.Categories.Include(p => p.Products).FirstOrDefaultAsync(u => u.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            var existingCategory = await _db.Categories.AnyAsync(u=>u.Name == category.Name | u.CategoryId == category.CategoryId);
            if(existingCategory)
            {
                return BadRequest("Category already exists");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(category.Products == null)
            {
                category.Products = new List<Product>();
            }
           
            _db.Categories.Add(category);
           
            await _db.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }
            
            _db.Entry(category).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Categories.Any(c => c.CategoryId == id))
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
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _db.Categories.Include(p=>p.Products).FirstOrDefaultAsync(u => u.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }

            if (category.Products.Count > 0)
            {
                return BadRequest("Category has products");
            }
            else
            {
                _db.Categories.Remove(category);
            }
            await _db.SaveChangesAsync();
            return Ok();


        }
    }
}
