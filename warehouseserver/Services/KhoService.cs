using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class KhoService
    {
        private readonly HttpClient _httpClient;

        public KhoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Kho>> GetAllKho()
        {
            return await _httpClient.GetFromJsonAsync<List<Kho>>("api/kho/getall");
        }

       
        public async Task<Kho> GetKhoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Kho>($"api/kho/get/{id}") ?? new Kho();
        }
        public async Task<bool> UpdateKho(Kho kho)
        {
            var response = await _httpClient.PutAsJsonAsync("api/kho/update", kho);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteKho(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/kho/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
