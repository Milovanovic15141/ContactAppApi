using ContactAppApi.Data;
using ContactAppApi.DTOs;
using ContactAppApi.Services.Jwt;
using Microsoft.EntityFrameworkCore;

namespace ContactAppApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public UserService(AppDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<LoginSuccessDto> Authenticate(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
            if (user == null)
            {
                return null;
            }

            var token = _jwtService.GenerateToken(user);

            return new LoginSuccessDto { Token = token, UserId = user.Id};
        }
    }
}
