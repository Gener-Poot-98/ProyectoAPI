using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Entity.DTO
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}
