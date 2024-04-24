using ProyectoAPICore.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Business.Repository.Interface
{
    public interface IAuthServices
    {
        Task<AuthenticationResponseDTO> Login(LoginDTO login);
    }
}
