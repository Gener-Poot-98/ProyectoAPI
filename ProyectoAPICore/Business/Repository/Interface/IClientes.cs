using ProyectoAPICore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Business.Repository.Interface
{
    public interface IClientes
    {
        public string ConnectionString { get; set; }
        Task<IEnumerable<ClientesInfo>> GetClientes(string email);
    }
}
