using backendAPI.Data.Entities.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendAPI.Data.Entities
{
    [Table("tblBaskets")]
    public class BasketEntity
    {
        /// <summary>
        /// Кількість товару
        /// </summary>
        public int Quintity { get; set; }

        /// <summary>
        /// Користувач
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual UserEntity User { get; set; }
        //public virtual ProductEntity Product { get; set; }
    }
}
