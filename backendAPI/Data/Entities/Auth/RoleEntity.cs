using Microsoft.AspNetCore.Identity;

namespace backendAPI.Data.Entities.Auth
{
    public class RoleEntity : IdentityRole<int>
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Зазначити автоінкрементний Id
        //public int Id { get; set; }
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
