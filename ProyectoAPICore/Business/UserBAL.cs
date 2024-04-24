using ProyectoAPICore.Business.Repository.Interface;
using ProyectoAPICore.Data;
using ProyectoAPICore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Business
{
    public class UserBAL : IUser
    {
        #region Properties...
        private UserDAL _UserDAL;
        public string ConnectionString { get => _UserDAL._ConnectionString; set => _UserDAL = new UserDAL() { _ConnectionString = value }; }
        #endregion

        #region Methods...
        public async Task<Entity.UserInfo?> GetUser(DTOUser User)
        {
            try
            {
                return await _UserDAL.GetUser(User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
