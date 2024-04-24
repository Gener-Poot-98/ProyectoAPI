using Azure;
using Microsoft.AspNetCore.JsonPatch;
using ProyectoAPICore.Business.Repository.Interface;
using ProyectoAPICore.Data;
using ProyectoAPICore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SOLTUM.Framework.Utilities.TaskbotClient;

namespace ProyectoAPICore.Business
{
    public class ClientesBAL : IClientes
    {
        #region Properties...
        private ClientesDAL _clientesDAL;
        public string ConnectionString { get => _clientesDAL._ConnectionString; set => _clientesDAL = new ClientesDAL() { _ConnectionString = value }; }
        #endregion

        #region Methods...
        public async Task<int> SetClientes(List<ClientesInfo> info)
        {
            try
            {
                return await _clientesDAL.SetClientes(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ClientesInfo>> GetClientes(string Correo)
        {
            try
            {
                return await _clientesDAL.GetClientes(Correo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClientesInfo> UpdateClientePatchAsync(int Id, JsonPatchDocument<ClientesInfo> ClienteDocument)
        {
            try
            {
                return await _clientesDAL.UpdateClientePatchAsync(Id, ClienteDocument);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
