using M295_TodoServiceAndAutomapper.Configuration;
using M295_TodoServiceAndAutomapper.Models.DTO.Requests;
using M295_TodoServiceAndAutomapper.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace M295_TodoServiceAndAutomapper.Services
{
    public class AuthManagementService : IAuthManagementService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementService(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<RegistrationResponse> Register(UserRegistrationRequestDTO user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return new RegistrationResponse
                {
                    Success = false,
                    Errors = new List<string> { "E-Mail-Adresse existiert bereits." }
                };
            }

            var newUser = new IdentityUser { Email = user.Email, UserName = user.Username };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);

            if (!isCreated.Succeeded)
            {
                return new RegistrationResponse
                {
                    Success = false,
                    Errors = isCreated.Errors.Select(x => x.Description).ToList()
                };
            }

            var jwtToken = GenerateJwtToken(newUser);

            return new RegistrationResponse
            {
                Success = true,
                Token = jwtToken
            };
        }

        public async Task<RegistrationResponse> Login(UserLoginRequest user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null || !await _userManager.CheckPasswordAsync(existingUser, user.Password))
            {
                return new RegistrationResponse
                {
                    Success = false,
                    Errors = new List<string> { "Ungültige Authentifizierungsanfrage" }
                };
            }

            var jwtToken = GenerateJwtToken(existingUser);

            return new RegistrationResponse
            {
                Success = true,
                Token = jwtToken
            };
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}