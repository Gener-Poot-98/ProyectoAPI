using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ProyectoAPICore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.Data
{
    public class UserDAL
    {
        #region Properties...
        public string _ConnectionString { get; set; }
        #endregion

        #region Methods...
        public async Task<Entity.UserInfo?> GetUser(DTOUser User)
        {
            try
            {
                string SQL = $"SELECT * FROM Users WHERE Email = @Email AND Pwd = @Password";
                Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
                parameters.Add("@Email", User.Email);
                parameters.Add("@Password", User.Pwd);

                // Utiliza el método QueryFirstOrDefaultAsync para obtener solo un usuario
                return await SOLTUM.Framework.Utilities.SQLHelper.QueryFirstAsync<Entity.UserInfo>(SQL, parameters, _ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
