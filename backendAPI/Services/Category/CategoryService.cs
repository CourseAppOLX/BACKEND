//using backendAPI.Data.Entities.category;
//using backendAPI.Data;
//using Microsoft.EntityFrameworkCore;

//namespace backendAPI.Services.Category
//{
//    public class CategoryService
//    {
//        private readonly AppEFContext _dbContext; 

//        public CategoryService(AppEFContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public  async Task<List<CategoryEntity>> GetAllCategoriesAsync()
//        {
//            return await _dbContext.Categories.ToListAsync();
//        }

//        public async Task<CategoryEntity> GetCategoryByIdAsync(int categoryId)
//        {
//            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
//        }

//        public async Task<CategoryEntity> CreateCategoryAsync(CategoryEntity category)
//        {
//            _dbContext.Categories.Add(category);
//            await _dbContext.SaveChangesAsync();
//            return category;
//        }

//        public async Task<CategoryEntity> UpdateCategoryAsync(int categoryId, CategoryEntity updatedCategory)
//        {
//            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
//            if (existingCategory != null)
//            {
//                existingCategory.Name = updatedCategory.Name;
//                existingCategory.Description = updatedCategory.Description;
//                existingCategory.ParentCategoryId = categoryId;
//                // Оновіть інші властивості за потребою
//                await _dbContext.SaveChangesAsync();
//            }
//            return existingCategory;
//        }

//        public async Task<bool> DeleteCategoryAsync(int categoryId)
//        {
//            var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
//            if (categoryToDelete != null)
//            {
//                _dbContext.Categories.Remove(categoryToDelete);
//                await _dbContext.SaveChangesAsync();
//                return true;
//            }
//            return false;
//        }
//    }
//}
