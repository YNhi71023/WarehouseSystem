using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class LoaiSanPhamService
    {
        private readonly HttpClient _httpClient;

        public LoaiSanPhamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LoaiSanPham>> GetAllLoaiSanPham()
        {
            return await _httpClient.GetFromJsonAsync<List<LoaiSanPham>>("api/loaisanpham/getall");
        }
        public async Task<LoaiSanPham> GetLoaiSanPhamById(int id)
        {
            return await _httpClient.GetFromJsonAsync<LoaiSanPham>($"api/loaisanpham/get/{id}") ?? new LoaiSanPham();
        }

        public async Task<bool> UpdateLoaiSanPham(LoaiSanPham loaisanpham)
        {
            var response = await _httpClient.PutAsJsonAsync("api/loaisanpham/update", loaisanpham);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteLoaiSanPham(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/loaisanpham/delete/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
