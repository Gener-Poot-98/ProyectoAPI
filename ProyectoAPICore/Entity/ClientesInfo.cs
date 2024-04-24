using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Entity
{
    public class ClientesInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
    }

    public class DTOCliente
    {
        public string Email { get; set; }
    }
}
