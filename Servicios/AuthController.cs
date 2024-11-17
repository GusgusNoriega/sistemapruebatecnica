using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Servicios
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string key = "clave_super_secreta_para_jwt"; // Debe ser la misma clave que en Program.cs

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validación básica de usuario (puedes reemplazar esto con tu lógica de autenticación)
            if (request.Username != "admin" || request.Password != "password")
            {
                return Unauthorized(new { message = "Usuario o contraseña incorrectos." });
            }

            // Crear los claims para el token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, "Admin") // Puedes agregar roles si es necesario
            };

            // Generar el token
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }

    // Modelo para la solicitud de inicio de sesión
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}