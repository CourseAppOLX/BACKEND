//using backendAPI.Abstract;
//using backendAPI.Data;
//using backendAPI.Data.Entities.Auth;
//using backendAPI.Data.Entities.category;
//using backendAPI.Models.Category;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace backendAPI.Controllers.Category
//{


//    [ApiController]
//    [Route("api/Categories")]
//    public class CategoryController : ControllerBase
//    {


//       // private readonly CategoryViewModel _categoryViewModel;
//       // private readonly CategoryService _categoryService;

//        private readonly IEnumerable<CategoryEntity> _listcategory;
//        private readonly AppEFContext _dbContext;
//        public CategoryController(AppEFContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        // Тут будуть ваши методи контролера.
//        [HttpGet]
//        [Route("list")]

//        public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetAllCategories()
//    {
//        var categories = await _dbContext.Categories.ToListAsync();
//            return Ok(categories);
//    }

//    [HttpGet("{name}")]

//    public async Task<ActionResult<CategoryEntity>> GetCategoryById(string Name)
//    {
//        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == Name );

//            if (category == null)
//        {
//            return NotFound(); // Повертаємо 404, якщо категорія не знайдена.
//        }

//        return Ok(category);
//    }
//    [HttpPost]
//        [Route("create")]
//        public async Task<ActionResult<CategoryEntity>> CreateCategory(CategoryEntity category)
//    {
//            if(category == null)
//                return BadRequest();
//            else
//            {
//                // await _dbContext.Categories.Add(category);
//                 await _dbContext.Categories.AddAsync(category);
//                 await _dbContext.SaveChangesAsync();
//                 return category;
//            }


//           // return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
//    }
//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateCategory(int categoryId, CategoryViewModel category/*, CategoryUpdateModel model*/)
//    {
//            var updatedCategory = new CategoryEntity()
//            {
//                Name = category.Name,
//                Description = category.Description,
//                Image = category.ImageFile,
//                ParentCategoryId = category.ParentCategoryId
//            };
//       // var updatedCategory = await CategoryService.UpdateCategoryAsync(id, model);
//            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
//            if (existingCategory != null)
//            {
//                existingCategory.Name = updatedCategory.Name;
//                existingCategory.Description = updatedCategory.Description;
//                existingCategory.ParentCategoryId = categoryId;
//                // Оновіть інші властивості за потребою
//                await _dbContext.SaveChangesAsync();
//            }
//            //return existingCategory;

//            if (updatedCategory == null)
//                {
//                     return NotFound(); // Повертаємо 404, якщо категорія не знайдена.
//                }

//        return NoContent(); // 204 No Content означає успішне оновлення.
//    }
//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteCategory(int categoryId)
//    {
//       // var deletedCategory = await CategoryService.DeleteCategoryAsync(id);
//            var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
//            if (categoryToDelete != null)
//            {
//                _dbContext.Categories.Remove(categoryToDelete);
//                await _dbContext.SaveChangesAsync();
//                return NoContent(); // 204 No Content означає успішне видалення.
//            }
//            return NotFound(); // Повертаємо 404, якщо категорія не знайдена.


//    }





//}


//}

using backendAPI.Data;
using backendAPI.Data.Entities.category;
using backendAPI.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Controllers.Category
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : ControllerBase
    {
        //private readonly IEnumerable<CategoryEntity> _listcategory;
        private readonly AppEFContext _dbContext;

        public CategoryController(AppEFContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetAllCategories()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CategoryEntity>> GetCategoryByName(string name)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);

            if (category == null)
            {
                return NotFound(); // Повертаємо 404, якщо категорія не знайдена.
            }

            return Ok(category);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CategoryEntity>> CreateCategory(CategoryEntity category)
        {
            if (category == null)
                return BadRequest();
            else
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateCategory(string name, CategoryViewModel category)
        {
            var updatedCategory = new CategoryEntity()
            {
                Name = category.Name,
                Description = category.Description,
                Image = category.ImageFile,
                ParentCategoryId = category.ParentCategoryId
            };

            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);

            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                existingCategory.Description = updatedCategory.Description;
                existingCategory.ParentCategoryId = updatedCategory.ParentCategoryId;
                // Оновіть інші властивості за потребою
                await _dbContext.SaveChangesAsync();
                return NoContent(); // 204 No Content означає успішне оновлення.
            }

            return NotFound(); // Повертаємо 404, якщо категорія не знайдена.
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteCategory(string name)
        {
            var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);

            if (categoryToDelete != null)
            {
                _dbContext.Categories.Remove(categoryToDelete);
                await _dbContext.SaveChangesAsync();
                return NoContent(); // 204 No Content означає успішне видалення.
            }

            return NotFound(); // Повертаємо 404, якщо категорія не знайдена.
        }
    }
}

