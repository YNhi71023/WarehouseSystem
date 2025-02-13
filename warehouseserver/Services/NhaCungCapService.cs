using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class NhaCungCapService
    {
        private readonly HttpClient _httpClient;

        public NhaCungCapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NhaCungCap>> GetAllNhaCungCap()
        {
            return await _httpClient.GetFromJsonAsync<List<NhaCungCap>>("api/nhacungcap/getall");
        }
        public async Task<NhaCungCap> GetNhaCungCapById(int id)
        {
            return await _httpClient.GetFromJsonAsync<NhaCungCap>($"api/nhacungcap/get/{id}") ?? new NhaCungCap();
        }

        public async Task<bool> UpdateNhaCungCap(NhaCungCap nhacungcap)
        {
            var response = await _httpClient.PutAsJsonAsync("api/nhacungcap/update", nhacungcap);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteNhaCungCap(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/nhacungcap/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
