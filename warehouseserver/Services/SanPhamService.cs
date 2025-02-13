using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class SanPhamService
    {
        private readonly HttpClient _httpClient;

        public SanPhamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SanPham>> GetAllSanPham()
        {
            return await _httpClient.GetFromJsonAsync<List<SanPham>>("api/sanpham/getall");
        }
        public async Task<SanPham> GetSanPhamById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SanPham>($"api/sanpham/get/{id}") ?? new SanPham();
        }
        public async Task<bool> UpdateSanPham(SanPham sanpham)
        {
            var response = await _httpClient.PutAsJsonAsync("api/sanpham/update", sanpham);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteSanPham(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/sanpham/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
