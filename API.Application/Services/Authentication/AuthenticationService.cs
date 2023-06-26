using API.Application.Common.Interfaces.Authentication;
using API.Domain.Entities;

namespace API.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private static readonly List<User> users = new();

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        => _jwtTokenGenerator = jwtTokenGenerator;

    public AuthenticationResult Login(string email, string password)
    {
        if(users.FirstOrDefault(x => x.Email == email) is not User user)
        {
            throw new Exception("User does not exists");
        }

        if(user.Password != password)
        {
            throw new Exception("Email or password is wrong");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string name, string email, string password)
    {
        if(users.FirstOrDefault(x => x.Email == email) is not null)
        {
            throw new Exception("User with email already exists");
        }
        var user = new User {
            Name = name,
            Email = email,
            Password = password
        };

        users.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}