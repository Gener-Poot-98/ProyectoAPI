using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoAPICore.Business.Repository.Interface;
using ProyectoAPICore.Entity.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Business
{
    public class AuthServices : IAuthServices
    {
        #region Global Variables...
        private IConfiguration _configuration;
        #endregion

        #region Constructor...
        public AuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Methods...
        private bool IsValidUser(LoginDTO credentials)
        {
            string UserSystem = _configuration["Credencials:UserApi"]?.ToString();
            string PasswordSystem = _configuration["Credencials:PasswordApi"]?.ToString();

            if (UserSystem == credentials.Username && PasswordSystem == credentials.Password)
                return true;
            else
                return false;
        }
        private string GenerateToken(DateTime fechaActual, LoginDTO auth, TimeSpan tiempoValidez)
        {
            try
            {
                DateTime fechaExpiracion = fechaActual.Add(tiempoValidez);

                //Configuramos las claims
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,auth.Username.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,
                        new DateTimeOffset(fechaActual).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                        ClaimValueTypes.Integer64
                ),
                new Claim("NameIdentifier", auth.Username),
                };

                //Añadimos las credenciales
                var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["KeyTokenJWT"])),
                        SecurityAlgorithms.HmacSha256Signature
                );

                //Configuracion del jwt token
                var jwt = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    notBefore: fechaActual,
                    expires: fechaExpiracion,
                    signingCredentials: signingCredentials
                );

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                return encodedJwt;
            }
            catch (Exception e)
            {
                throw new Exception("Token" + e.Message);
            }
        }
        public async Task<AuthenticationResponseDTO> Login(LoginDTO login)
        {
            var token = "";
            DateTime fechaExpiracion = DateTime.MinValue;
            bool isValid = IsValidUser(login);

            if (isValid)
            {
                DateTime fechaActual = DateTime.UtcNow;
                var validez = TimeSpan.FromMinutes(30);
                fechaExpiracion = fechaActual.Add(validez);
                token = GenerateToken(fechaActual, login, validez);
            }

            return new AuthenticationResponseDTO() { FechaExpiracion = fechaExpiracion, Token = token };
        }
        #endregion
    }
}
