using ContactAppApi.DTOs;

namespace ContactAppApi.Services.User
{
    public interface IUserService
    {
        Task<LoginSuccessDto> Authenticate(LoginDto loginDto);
    }
}
