namespace ContactAppApi.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(ContactAppApi.Models.User user);
    }
}
