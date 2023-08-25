using backendAPI.Data.Entities.Auth;

namespace backendAPI.Abstract
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(UserEntity user);
    }
}
