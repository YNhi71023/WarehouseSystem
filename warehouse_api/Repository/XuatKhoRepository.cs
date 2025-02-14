using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using warehouse_api.Models;

namespace warehouse_api.Repository
{
    public class XuatKhoRepository
    {
        private readonly string _connectionString;

        public XuatKhoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<XuatKho>> GetAllXuatKho()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<XuatKho>("[dbo].[XuatKho.GetAll]", commandType: CommandType.StoredProcedure);
        }
        public async Task<NhapKho?> GetByIdXuatKho(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<NhapKho>(
                    "[dbo].[XuatKho.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateXuatKho(XuatKho xk)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@sophieuxuat", xk.SoPhieuXuatKho);
                parameters.Add("@khoid", xk.KhoID);
                parameters.Add("@ngayxuat", xk.NgayXuatKho);
                parameters.Add("@ghichu", xk.GhiChu);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[XuatKho.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }


        public async Task<bool> DeleteXuatKho(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync("[dbo].[XuatKho.Delete]", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }
    }
}
