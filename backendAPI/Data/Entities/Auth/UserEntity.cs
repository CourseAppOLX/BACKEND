using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendAPI.Data.Entities.Auth
{
    public class UserEntity : IdentityUser<int>
    {
      

        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Image { get; set; } = "default-image.jpg";
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
