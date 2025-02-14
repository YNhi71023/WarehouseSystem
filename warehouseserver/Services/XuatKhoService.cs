using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class XuatKhoService
    {
        private readonly HttpClient _httpClient;
        public XuatKhoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<XuatKho>> GetAllXuatKho()
        {
            return await _httpClient.GetFromJsonAsync<List<XuatKho>>("api/xuatkho/getall");
        }
        public async Task<XuatKho> GetXuatKhoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<XuatKho>($"api/xuatkho/get/{id}") ?? new XuatKho();
        }
        public async Task<bool> DeleteXuatKho(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/xuatkho/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
