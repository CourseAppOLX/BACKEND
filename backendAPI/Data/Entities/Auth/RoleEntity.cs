using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843

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
