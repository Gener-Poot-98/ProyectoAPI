using Azure;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.JsonPatch;
using ProyectoAPICore.Entity;
using SOLTUM.Framework.Utilities.TcpSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SOLTUM.Framework.Utilities.TaskbotClient;

namespace ProyectoAPICore.Data
{
    public class ClientesDAL
    {
        #region Properties...
        public string _ConnectionString { get; set; }
        #endregion

        #region Methods...
        public async Task<int> SetClientes(List<ClientesInfo> info)
        {
            try
            {
                Task.Run(() => SOLTUM.Framework.Utilities.SQLHelper.BulkInsertList<ClientesInfo>(info, "Clientes", _ConnectionString)).GetAwaiter();
                return info.Count();
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
                string SQL = $"SELECT * FROM Clientes WHERE Email = '{Correo}'";
                Dapper.DynamicParameters dynamic = new Dapper.DynamicParameters();
                dynamic.Add("@Email", Correo);
                return await SOLTUM.Framework.Utilities.SQLHelper.QueryAsync<ClientesInfo>(SQL, dynamic, _ConnectionString, 999);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClientesInfo> GetClienteByIdAsync(int Id)
        {
            try
            {
                string SQL = $"SELECT * FROM Clientes WHERE Id = @Id";
                Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
                parameters.Add("@Id", Id);

                // Utiliza el método QueryFirstOrDefaultAsync para obtener solo un cliente
                return await SOLTUM.Framework.Utilities.SQLHelper.QueryFirstAsync<ClientesInfo>(SQL, parameters, _ConnectionString);
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
                var ClienteInfo = await GetClienteByIdAsync(Id);

                if (ClienteInfo == null)
                    return ClienteInfo;

                // Aplicar los cambios del JsonPatchDocument al ClienteInfo
                ClienteDocument.ApplyTo(ClienteInfo);

                // Generar la cláusula SET para los campos modificados
                List<string> FieldsToUpdate = new List<string>();
                Dapper.DynamicParameters Parameters = new Dapper.DynamicParameters();

                foreach (var Entry in ClienteDocument.Operations)
                {
                    switch (Entry.path.ToUpper())
                    {
                        case "NOMBRE":
                        case "APELLIDOS":
                        case "EMAIL":
                            FieldsToUpdate.Add($"{Entry.path} = @{Entry.path}");
                            Parameters.Add($"@{Entry.path}", Entry.value);
                            break;
                    }
                }

                // Construir la cláusula SET
                string SetClause = string.Join(", ", FieldsToUpdate);

                // Actualizar el cliente en la base de datos
                var sql = $"UPDATE Clientes SET {SetClause} WHERE Id = @Id";
                Parameters.Add("@Id", ClienteInfo.Id);

                await SOLTUM.Framework.Utilities.SQLHelper.ExecuteAsync(sql.ToString(), Parameters, _ConnectionString);

                return ClienteInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
