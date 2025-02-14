using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class NhapKhoService
    {
        private readonly HttpClient _httpClient;

        public NhapKhoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NhapKho>> GetAllNhapKho()
        {
            return await _httpClient.GetFromJsonAsync<List<NhapKho>>("api/nhapkho/getall");
        }


        public async Task<NhapKho> GetNhapKhoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<NhapKho>($"api/nhapkho/get/{id}") ?? new NhapKho();
        }
        public async Task<bool> DeleteNhapKho(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/nhapkho/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
