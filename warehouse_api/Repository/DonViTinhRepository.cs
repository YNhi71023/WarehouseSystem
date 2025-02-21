using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using warehouse_api.Models;
namespace warehouse_api.Repository
{
    public class DonViTinhRepository
    {
        private readonly string _connectionString;

        public DonViTinhRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

       
        public async Task<IEnumerable<DonViTinh>> GetAllDonViTinh()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //var parameters = new { user_login };

                return await connection.QueryAsync<DonViTinh>(
                    "[dbo].[DonViTinh.GetAll]",
                    commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<DonViTinh?> GetByIdDonViTinh( int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                return await connection.QueryFirstOrDefaultAsync<DonViTinh>(
                    "[dbo].[DonViTinh.Get]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> CreateDonViTinh(DonViTinh d)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@tendonvi", d.TenDonViTinh);
                parameters.Add("@ghichu", d.GhiChu);

                var result = await connection.ExecuteScalarAsync<string>(
                    "[dbo].[DonViTinh.Create]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? "Không có thông báo.";
            }
        }
       
        public async Task<DonViTinh?> UpdateDonViTinh(DonViTinh d)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@id", d.Id);
                parameters.Add("@tendvt", d.TenDonViTinh);
                parameters.Add("@ghichu", d.GhiChu);

                return await connection.QueryFirstOrDefaultAsync<DonViTinh>(
                    "[dbo].[DonViTinh.Update]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public async Task<bool> DeleteDonViTinh(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);

                var affectedRows = await connection.ExecuteAsync("[dbo].[DonViTinh.Delete]", parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }


    }
}
