using Lab10_OmarChoque.Application.DTOs;
using Lab10_OmarChoque.Application.Interfaces;
using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lab10_OmarChoque.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly IJwtService _jwtService;

    public AuthController(
        IUserRepository repository,
        IJwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    // ---------------- LOGIN ----------------
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _repository.GetByUsernameAsync(dto.Username);

        if (user == null)
            return Unauthorized("Usuario no existe");

        if (user.PasswordHash != dto.Password)
            return Unauthorized("Password incorrecta");

        var token = _jwtService.GenerateToken(user.Username);

        return Ok(new
        {
            token
        });
    }

    // ---------------- REGISTER ----------------
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var exists = await _repository.GetByUsernameAsync(dto.Username);

        if (exists != null)
            return BadRequest("El usuario ya existe");

        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = dto.Username,
            PasswordHash = dto.Password,
            Email = dto.Email,

            // ✅ FIX IMPORTANTE (POSTGRES + UTC)
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(user);

        return Ok(new
        {
            message = "Usuario registrado correctamente"
        });
    }
}