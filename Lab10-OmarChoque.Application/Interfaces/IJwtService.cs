namespace Lab10_OmarChoque.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(string username);
}