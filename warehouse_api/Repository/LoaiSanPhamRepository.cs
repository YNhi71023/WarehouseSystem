using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using warehouse_api.Models;

namespace warehouse_api.Repository
{
    public class LoaiSanPhamRepository
    {
        private readonly string _connectionString;

        public LoaiSanPhamRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<LoaiSanPham>> GetAllLoaiSanPham()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<LoaiSanPham>("[dbo].[LoaiSanPham.GetAll]", commandType: CommandType.StoredProcedure);
        }
        public async Task<LoaiSanPham?> GetByIdLoaiSanPham(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<LoaiSanPham>(
                    "[dbo].[LoaiSanPham.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateLoaiSanPham(LoaiSanPham l)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@malsp", l.MaLSP);
                parameters.Add("@tenlsp", l.TenLSP);
                parameters.Add("@ghichu", l.GhiChu);
                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[LoaiSanPham.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                return result ?? "Không có thông báo.";
            }
        }
        public async Task<LoaiSanPham?> UpdateLoaiSanPham(LoaiSanPham l)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@id", l.Id);
                parameters.Add("@malsp", l.MaLSP);
                parameters.Add("@tenlsp", l.TenLSP);
                parameters.Add("@ghichu", l.GhiChu);

                return await connection.QueryFirstOrDefaultAsync<LoaiSanPham>(
                    "[dbo].[LoaiSanPham.Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }


        public async Task<bool> DeleteLoaiSanPham(int id)
        {
            using (var connection = new SqlConnection(_connectionString)) { 
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);
                var affectedRows = await connection.ExecuteAsync(
                    "[dbo].[LoaiSanPham.Delete]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

    }
}
