using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using warehouse_api.Models;

namespace warehouse_api.Repository
{
    public class SanPhamRepository
    {

        private readonly string _connectionString;

        public SanPhamRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<SanPham>> GetAllSanPham()
        {
            using (var connection = new SqlConnection(_connectionString)) {
                return await connection.QueryAsync<SanPham>(
                    "[dbo].[SanPham.GetAll]",
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task<SanPham?> GetByIdSanPham(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<SanPham>(
                    "[dbo].[SanPham.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateSanPham( SanPham s)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@masp", s.MaSP);
                parameters.Add("@tensp", s.TenSP);
                parameters.Add("@lsp_id", s.LSPId);
                parameters.Add("@dvt_id", s.DVTId);
                parameters.Add("@ghichu", s.GhiChu);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[SanPham.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }
        public async Task<SanPham?> UpdateSanPham(SanPham s)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@id", s.Id);
                parameters.Add("@masp", s.MaSP);
                parameters.Add("@tensp", s.TenSP);
                parameters.Add("@lsp_id", s.LSPId);
                parameters.Add("@dvt_id", s.DVTId);

                return await connection.QueryFirstOrDefaultAsync<SanPham>(
                    "[dbo].[SanPham.Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public async Task<bool> DeleteSanPham( int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync("[dbo].[SanPham.Delete]", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }


    }
}
