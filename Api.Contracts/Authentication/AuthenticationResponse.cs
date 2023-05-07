namespace API.Contracts.Authentication;

public record AuthenticationResponse (
    int Id,
    string Name,
    string Email,
    string Token
);