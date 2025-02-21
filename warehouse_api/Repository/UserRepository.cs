using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using warehouse_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace warehouse_api.Repository
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<string> CreateUser( User u)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@madangnhap", u.MaDangNhap);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[User.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }
        public async Task<DataTable> LoginUser(User u)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[LoginUser]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@madangnhap", u.MaDangNhap));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
    }
}
