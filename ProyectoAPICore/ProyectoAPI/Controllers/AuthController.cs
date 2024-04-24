using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoAPICore.Business.Repository.Interface;
using ProyectoAPICore.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        #region Properties...
        private IUser _user;
        private IConfiguration _configuration;
        public string _ConnectionString { get; set; }
        #endregion

        #region Constructors...
        public AuthController(IConfiguration Configuration, IUser User)
        {
            _configuration = Configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            _user = User;
            _user.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        //[HttpPost]
        //public async Task<IActionResult> Login(DTOUser DTOUser)
        //{
        //    var user = await _user.GetUser(DTOUser);

        //    if (user is null)
        //        return BadRequest(new { message = "Credenciales Inválidas" });

        //    // Generar un token
        //    string jwtToken = GenerateToken(user);

        //    return Ok(new { token = jwtToken });
        //}

        //private string GenerateToken(UserInfo User)
        //{
        //    var Claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name, User.Username),
        //        new Claim(ClaimTypes.Email, User.Email)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Key").Value));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var securityToken = new JwtSecurityToken(
        //                        claims: Claims,
        //                        expires: DateTime.Now.AddMinutes(60),
        //                        signingCredentials: creds);

        //    var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        //    return token;
        //}
    }
}
