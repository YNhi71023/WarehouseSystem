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
            using (var connection = new SqlConnection(_connectionString))
            {

                return await connection.QueryAsync<NhapKho>(
                "[dbo].[NhapKho.GetAll]",
                    commandType: CommandType.StoredProcedure
                );
            };

            
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

        public async Task<IEnumerable<BaoCaoNhapKhoDate>> GetPhieuNhapByDateRange(DateTime fromDate, DateTime toDate)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new { fromdate = fromDate, todate = toDate };

            var result = await connection.QueryAsync<BaoCaoNhapKhoDate>(
                "[dbo].[GetPhieuNhapByDateRange]",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<ChiTietNhapKho>> GetChiTietNhapKhoAsync(int nhapKhoId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<ChiTietNhapKho>(
                "[dbo].[ChiTietNhapKho.Get]",
                new { nhapkhoid = nhapKhoId },
                commandType: CommandType.StoredProcedure);
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
        public async Task<string> CreateChiTietNhapKho(ChiTietNhapKhoCreate c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nhapkhoid", c.NhapKhoId);
                parameters.Add("@sanphamid", c.SanPhamId);
                parameters.Add("@soluong", c.SLNhap);
                parameters.Add("@dongia", c.DonGiaNhap);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[ChiTietNhapKho.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }

        public async Task<bool> UpdateChiTietNhapKho(ChiTietNhapKhoCreate c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nhapkhoid", c.NhapKhoId);
                parameters.Add("@sanphamid", c.SanPhamId);
                parameters.Add("@slnhap", c.SLNhap);
                parameters.Add("@dongianhap", c.DonGiaNhap);

                var affectedRows = await connection.ExecuteAsync(
                    "[dbo].[ChiTietNhapKho.Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return affectedRows > 0; 
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
