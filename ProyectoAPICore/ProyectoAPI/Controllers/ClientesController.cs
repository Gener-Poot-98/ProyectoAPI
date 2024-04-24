using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoAPICore.Business;
using ProyectoAPICore.Business.Repository.Interface;
using ProyectoAPICore.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        #region Properties...
        private IClientes _clientes;
        private IConfiguration _configuration;
        public string _ConnectionString { get; set; }
        #endregion

        #region Constructors...
        public ClientesController(IConfiguration Configuration, IClientes Clientes)
        {
            _configuration = Configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            //ClientesBAL = new ClientesBAL() { _ConnectionString = _ConnectionString };
            _clientes = Clientes;
            _clientes.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Methods...
        //[HttpPost("SetClientes")]
        //public async Task<IActionResult> SetClientes([FromBody] List<ClientesInfo> info)
        //{
        //    try
        //    {
        //        return Ok(await ClientesBAL.SetClientes(info));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpGet("GetClientes")]
        public async Task<IActionResult> GetClientes([FromHeader] string Correo)
        {
            try
            {
                return Ok(await _clientes.GetClientes(Correo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpPatch("{Id}")]
        //public async Task<IActionResult> UpdateCliente([FromRoute] int Id, [FromBody] JsonPatchDocument<ClientesInfo> ClienteDocument)
        //{
        //    try
        //    {
        //        var UpdatedCliente = await ClientesBAL.UpdateClientePatchAsync(Id, ClienteDocument);
        //        if (UpdatedCliente == null) return NotFound();
        //        return Ok(UpdatedCliente);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
    }
}
