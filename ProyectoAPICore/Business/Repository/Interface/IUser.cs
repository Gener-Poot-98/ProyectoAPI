using ProyectoAPICore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Business.Repository.Interface
{
    public interface IUser
    {
        public string ConnectionString { get; set; }
        Task<UserInfo> GetUser(DTOUser User);
    }
}
