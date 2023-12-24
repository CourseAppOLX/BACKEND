using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendAPI.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategotyName { get; set; }
        public string Description { get; set; }
        public int? ParentCategry { get; set; } = 0;

        public string CategoryImage { get; set; } = "default-image.jpg";

    }
}
