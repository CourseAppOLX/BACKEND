using Microsoft.AspNetCore.Identity;

namespace backendAPI.Data.Entities.Auth
{
   
        public class UserRoleEntity : IdentityUserRole<int>
        {
            public virtual UserEntity User { get; set; }
            public virtual RoleEntity Role { get; set; }
        }
    
}
