using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnica.DataAccess
{
    public class Articulo : Interface.IArticulo
    {
        #region Atributos
        private readonly Interface.IConnectionManager connectionManager;

        #endregion

        public Articulo()
        {
          
        }

        public IEnumerable<Model.Articulo> Listar()
        {
            IEnumerable<Model.Articulo> result = null;
            using (var _connection = connectionManager.CreateConnection(ConnectionManager.Prueba_Key))
            {
               /* var resultado = _connection.Query<Model.Articulo(
                    "usp_ConsultaArticulos",
                    (a, b, c) =>
                    {
                        a.Marca = b;
                        return a;
                    },
                    commandType: System.Data.CommandType.StoredProcedure).to ;
                return resultado;*/
            }
            return result;
        }
    }
}
