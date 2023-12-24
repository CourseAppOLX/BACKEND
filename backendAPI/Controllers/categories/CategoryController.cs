using Microsoft.AspNetCore.Mvc;
using backendAPI.Data.Entities;
using System;
using System.Collections.Generic;
using backendAPI.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using backendAPI.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly List<CategoryEntity> _categories; // Замініть це на ваш реальний джерело даних
        private readonly AppEFContext _appEFContext;
        private readonly IMapper _mapper;
        public CategoryController(AppEFContext appEFContext, IMapper mapper)
        {

            _appEFContext = appEFContext;
            _mapper = mapper;
           
        }

        // GET: api/Category
        [HttpGet("list")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _appEFContext.Categories
                .Select(x => _mapper.Map<CategoryEntity>(x))
                .ToListAsync();
            return Ok(result);
        }

        // GET: api/Category/5
        [HttpGet("item{id}")]
        public async Task<ActionResult<CategoryEntity>> GetAsync(int id)
        {
            var category = await _appEFContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Category


        [HttpPost("create")]
        public async Task<IActionResult> Post([FromForm] CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto.CategoryImageFile != null)
                {
                    var fileExp = Path.GetExtension(categoryDto.CategoryImageFile.FileName);
                    var dirSave = Path.Combine(Directory.GetCurrentDirectory(), "images/category");

                    // Перевірка та створення директорії, якщо не існує
                    if (!Directory.Exists(dirSave))
                    {
                        Directory.CreateDirectory(dirSave);
                    }

                    // Генерація унікального імені файлу
                    var imageName = Guid.NewGuid().ToString() + fileExp;

                    using (var stream = System.IO.File.Create(Path.Combine(dirSave, imageName)))
                    {
                        await categoryDto.CategoryImageFile.CopyToAsync(stream);
                    }

                    var category = new CategoryEntity
                    {
                        Id = categoryDto.Id,
                        CategotyName = categoryDto.CategoryName,
                        ParentCategry = categoryDto.ParentCategryId,
                        Description = categoryDto.Description,
                        // Встановлення імені файлу в сутності
                        CategoryImage = imageName, // Змінено на ім'я файлу
                    };

                    //_categories.Add(category);
                    await _appEFContext.Categories.AddAsync(category);
                    await _appEFContext.SaveChangesAsync();
                    return Ok(category);
                    //return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
                }
                else
                {
                    return BadRequest("No image file provided");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }




        // PUT: api/Category/5
        [HttpPut("update{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CategoryDto categoryDto)
        {

            try
            {
                var existingCategory = await _appEFContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

                if (existingCategory == null)
                {
                    return NotFound();
                }

                if (categoryDto.CategoryImageFile != null)
                {
                    var fileExp = Path.GetExtension(categoryDto.CategoryImageFile.FileName);
                    var dirSave = Path.Combine(Directory.GetCurrentDirectory(), "images/category");

                    // Перевірка та створення директорії, якщо не існує
                    if (!Directory.Exists(dirSave))
                    {
                        Directory.CreateDirectory(dirSave);
                    }

                    // Генерація унікального імені файлу
                    var imageName = Guid.NewGuid().ToString() + fileExp;

                    using (var stream = System.IO.File.Create(Path.Combine(dirSave, imageName)))
                    {
                        await categoryDto.CategoryImageFile.CopyToAsync(stream);
                    }
                    var category = new CategoryEntity
                    {
                        Id = categoryDto.Id,
                        CategotyName = categoryDto.CategoryName,
                        ParentCategry = categoryDto.ParentCategryId,
                        // Встановлення імені файлу в сутності
                        CategoryImage = imageName, // Змінено на ім'я файлу
                    };

                    _appEFContext.Categories.Find(categoryDto.Id).CategotyName = category.CategotyName;
                    _appEFContext.Categories.Find(categoryDto.Id).ParentCategry = category.ParentCategry;
                    _appEFContext.Categories.Find(categoryDto.Id).CategoryImage = category.CategoryImage;

                    await _appEFContext.SaveChangesAsync();
                    return Ok(category);
                   

                    ////_categories.Add(category);
                    //await _appEFContext.Categories.AddAsync(category);

                    //return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
                }
                else
                {
                    return BadRequest("No image file provided");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
            //// Додайте перевірки та обробку помилок за необхідності
            //var existingCategory = await _appEFContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

            //if (existingCategory == null)
            //{
            //    return NotFound();
            //}

            //existingCategory.CategotyName = categoryDto.CategoryName;
            //existingCategory.ParentCategry = categoryDto.ParentCategory;
            ////existingCategory.CategotyImage = Convert.FromBase64String(categoryDto.CategotyImageFile);



            //await _appEFContext.Categories.AddAsync(existingCategory);
            //await _appEFContext.SaveChangesAsync();
            //return Ok(existingCategory);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            // Додайте перевірки та обробку помилок за необхідності
            var category = await _appEFContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _appEFContext.Categories.Remove(category);
            await _appEFContext.SaveChangesAsync();
            return Ok(category);

            return NoContent();
        }
    }
}
