using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;

namespace SqliteDapper.Demo.Database
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            var table_product = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table';");
            var tableName = table_product.ToList();
            var flagP = 0;
            var flagB = 0;
            for (int i = 0; i < tableName.Count; i++)
            {
                if (tableName[i] == "Product")
                {
                    flagP = 1;
                }

                else if (tableName[i] == "bill_detail")
                {
                    flagB = 1;
                }

            }
            Console.WriteLine("This is test" + flagP);
            Console.WriteLine("This is test" + flagB);
            if (flagP == 0)
            {
                Console.WriteLine("hello!!!!!!!!!!!Product");
                connection.Execute("Create Table Product (" +
                "Name VARCHAR(100) NOT NULL," +
                "Description VARCHAR(1000) NULL);");
            }
            if (flagB == 0)
            {
                Console.WriteLine("hello!!!!!!!!!!!bill_detail");
                connection.Execute("CREATE TABLE bill_detail (" +
                                    "PayerAccountId c(20) NOT NULL," +
                                    "UnblendedCost decimal(15, 10)," +
                                    "UnblendedRate decimal(15, 10)," +
                                    "UsageAccountId nvarchar(20)," +
                                    "UsageAmount decimal(15, 10)," +
                                    "UsageStartDate timestamp, " +
                                    "UsageEndDate timestamp, " +
                                    "ProductName nvarchar(254)" +
                                    ");");
            }
            return;

        }
    }
}
