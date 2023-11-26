using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendAPI.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategotyName { get; set; }
        public string? ParentCategry { get; set; }

        public string CategoryImage { get; set; } = "default-image.jpg";

    }
}
