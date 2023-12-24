namespace backendAPI.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Назва категорії
        /// </summary>
        /// <example>Name</example>
        public string CategoryName { get; set; }

        /// <summary>
        /// Опис
        /// </summary>
        /// <example>Description</example>
        public string Description { get; set; }

        /// <summary>
        /// Батьківська категорія
        /// </summary>
        /// <example>Parent</example>
        public int? ParentCategryId { get; set; } = 0;

        /// <summary>
        /// Фото
        /// </summary>
        /// <example>Image</example>
        public IFormFile CategoryImageFile { get; set; }
    }
}
