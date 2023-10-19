using System.ComponentModel.DataAnnotations;

namespace backendAPI.Models.Category
{
    public class CategoryViewModel
    {
        /// <summary>
        /// Назва
        /// </summary>
        [Required(ErrorMessage = "The 'Category Name' field is required.")]
        [StringLength(100, ErrorMessage = "Category name must be between 1 and 100 characters.", MinimumLength = 1)]
        public string Name { get; set; }
        /// <summary>
        /// Опис
        /// </summary>
        [StringLength(100, ErrorMessage = "Category description should not exceed 500 characters.")]
        public string Description { get; set; }
        ///<summary>
        /// Фото
        /// </summary>
        [Required(ErrorMessage = "An image file is required.")]
        public string ImageFile { get; set; }
        ///<summary>
        /// Батьківська категорія(НЕ Обовязково!)
        /// </summary>
        [Display(Name = "Parent Category")]
        public int? ParentCategoryId { get; set; }
    }
}
