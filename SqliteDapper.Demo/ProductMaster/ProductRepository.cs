using Dapper;
using hw_backend_api_enhancement.Model;
using Microsoft.Data.Sqlite;
using SqliteDapper.Demo.Database;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.ProductMaster
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ProductRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(BillDetail product)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
                "VALUES (@Name, @Description);", product);
        }
    }
}
