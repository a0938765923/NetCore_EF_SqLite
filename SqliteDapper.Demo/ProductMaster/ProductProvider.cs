using Dapper;
using hw_backend_api_enhancement.Model;
using Microsoft.Data.Sqlite;
using SqliteDapper.Demo.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.ProductMaster
{
    public class ProductProvider : IProductProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public ProductProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<dynamic>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<dynamic>("SELECT * FROM bill_detail;");
        }
    }
}
