using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using warehouse_api.Models;

namespace warehouse_api.Repository
{
    public class KhoRepository
    {
        private readonly string _connectionString;

        public KhoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<Kho>> GetAllKho()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Kho>(
                    "[dbo].[Kho.GetAll]",
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<Kho?> GetByIdKho(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<Kho>(
                    "[dbo].[Kho.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateKho(Kho k)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@tenkho", k.TenKho);
                parameters.Add("@ghichu", k.GhiChu);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[Kho.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }

        public async Task<Kho?> UpdateKho( Kho k)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@id", k.Id);
                parameters.Add("@tenkho", k.TenKho);
                parameters.Add("@ghichu", k.GhiChu);

                return await connection.QueryFirstOrDefaultAsync<Kho>(
                    "[dbo].[Kho.Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public async Task<bool> DeleteKho( int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync("[dbo].[Kho.Delete]", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }
    }
}
