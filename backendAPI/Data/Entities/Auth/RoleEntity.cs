using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
