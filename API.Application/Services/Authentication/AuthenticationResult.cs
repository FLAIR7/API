using API.Domain.Entities;

namespace API.Application.Services.Authentication;

public record AuthenticationResult (
    User User,
    string Token
);