using Microsoft.AspNetCore.Mvc;
using NewsAPI.Model;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        List<Category> categories = new List<Category>();
        public CategoriesController()
        {
            categories.Add(new Category("0", "Others"));
            categories.Add(new Category("1", "Course"));
            categories.Add(new Category("2", "Lab"));
        }

        /// <summary>
        /// GET Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCategories()
        {
            return Ok(categories);
        }

        /// <summary>
        /// GET Category
        /// </summary>
        /// <returns></returns>
        [HttpGet("{categoryId}")]
        public ActionResult GetCategory(string categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest("categoryId is can't be null");
            }
            Category? cat = categories.Find(cat => cat.Id == categoryId);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        /// <summary>
        /// DELETE Category
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(string categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest("categoryId is can't be null");
            }
            Category? cat = categories.Find(cat => cat.Id == categoryId);
            if (cat == null)
            {
                return NotFound();
            }
            categories.Remove(cat);
            return Ok();
        }

        /// <summary>
        /// POST Category
        /// </summary>
        /// <returns></returns>
        [HttpPost("{category}")]
        public ActionResult PostCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("The category transmited is null");
            }
            categories.Add(category);
            return Ok();
        }
        
        /// <summary>
        /// PUT Category
        /// </summary>
        /// <returns></returns>
        [HttpPut("{category}")]
        public ActionResult PutCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("The category transmited is null");
            }
            int index = categories.IndexOf(categories.Find(cat => cat.Id == category.Id));
            if (index == -1)
            {
                return NotFound();
            }
            categories[index] = category;
            return Ok();
        }
    }
}
