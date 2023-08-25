using Microsoft.AspNetCore.Identity;

namespace backendAPI.Data.Entities.Auth
{
    public class RoleEntity : IdentityRole<int>
    {
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
