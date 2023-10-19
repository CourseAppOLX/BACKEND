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
<<<<<<< HEAD
        public int? UserId { get; set; }
=======
        public int UserId { get; set; }
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843

        /// <summary>
        /// Продукт
        /// </summary>
        [ForeignKey("Product")]
<<<<<<< HEAD
        public int? ProductId { get; set; }

        public virtual UserEntity? User { get; set; }
=======
        public int ProductId { get; set; }

        public virtual UserEntity User { get; set; }
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843
        //public virtual ProductEntity Product { get; set; }
    }
}
