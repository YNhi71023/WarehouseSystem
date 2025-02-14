using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using warehouse_api.Models;

namespace warehouse_api.Repository
{
    public class NhapKhoRepository
    {
        private readonly string _connectionString;

        public NhapKhoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<NhapKho>> GetAllNhapKho()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<NhapKho>("[dbo].[NhapKho.GetAll]", commandType: CommandType.StoredProcedure);
        }
        public async Task<NhapKho?> GetByIdNhapKho(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<NhapKho>(
                    "[dbo].[NhapKho.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateNhapKho(NhapKho nk)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@sophieunhap", nk.SoPhieuNhapKho);
                parameters.Add("@khoid", nk.KhoId);
                parameters.Add("@nccid", nk.NCCId);
                parameters.Add("@ngaynhap", nk.NgayNhapKho);
                parameters.Add("@ghichu", nk.GhiChu);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[NhapKho.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }

       
        public async Task<bool> DeleteNhapKho(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync("[dbo].[NhapKho.Delete]", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }
    }
}
