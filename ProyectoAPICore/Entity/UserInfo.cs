using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Entity
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public DateTime FechaAlta { get; set; }
    }

    public class DTOUser
    {
        public string Email { get; set; }
        public string Pwd { get; set; }
    }
}
