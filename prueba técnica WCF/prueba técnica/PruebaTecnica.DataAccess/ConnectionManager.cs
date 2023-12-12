using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnica.DataAccess
{
    public class ConnectionManager
    {
        public const string Prueba_Key = "XXXXXXX";
        private readonly IConfiguration configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IDbConnection CreateConnection(string keyName)
        {
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(configuration, $"{keyName}"));
        }
    }
}
