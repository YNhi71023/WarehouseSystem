using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using warehouse_api.Models;

namespace warehouse_api.Repository
{
    public class NhaCungCapRepository
    {

        private readonly string _connectionString;

        public NhaCungCapRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<NhaCungCap>> GetAllNhaCungCap()
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                return await connection.QueryAsync<NhaCungCap>(
                    "[dbo].[NCC.GetAll]",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<NhaCungCap?> GetByIdNhaCungCap(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<NhaCungCap>(
                    "[dbo].[NCC.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateNhaCungCap(NhaCungCap n)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mancc", n.MaNCC);
                parameters.Add("@tenncc", n.TenNCC);
                parameters.Add("@ghichu", n.GhiChu);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[NCC.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }
        public async Task<NhaCungCap?> UpdateNhaCungCap(NhaCungCap n)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@id", n.Id);
                parameters.Add("@mancc", n.MaNCC);
                parameters.Add("@tenncc", n.TenNCC);
                parameters.Add("@ghichu", n.GhiChu);

                return await connection.QueryFirstOrDefaultAsync<NhaCungCap>(
                    "[dbo].[NCC.Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public async Task<bool> DeleteNhaCungCap(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync("[dbo].[NCC.Delete]", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

    }
}
