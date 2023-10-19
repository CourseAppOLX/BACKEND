using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace backendAPI.Data.Entities.category
{
    public class CategoryEntity
    {
      
        public string? Name { get; set; }

        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
    //public class CategoryUpdateModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public int? ParentCategoryId { get; set; }
    //}

    //public class CategoryCreateModel
    //{
       
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public int? ParentCategoryId { get; set; }
    //}

}
