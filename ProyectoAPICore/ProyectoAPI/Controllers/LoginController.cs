using Microsoft.AspNetCore.Mvc;
using ProyectoAPICore.Business;
using ProyectoAPICore.Business.Repository.Interface;
using ProyectoAPICore.Entity.DTO;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        #region Global Variables...
        private readonly IAuthServices _authServices;
        #endregion

        #region Constructor...
        public LoginController(IAuthServices services)
        {
            _authServices = services;
        }
        #endregion

        #region Methods...
        [HttpPost("Token")]
        public async Task<IActionResult> Token([FromBody] LoginDTO login)
        {
            try
            {
                var response = await _authServices.Login(login);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
