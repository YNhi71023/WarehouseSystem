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
        public async Task<List<ChiTietNhapKho>> GetChiTietNhapKhoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<ChiTietNhapKho>>($"api/nhapkho/chitiet/get/{id}");
        }

        public async Task<NhapKho> GetNhapKhoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<NhapKho>($"api/nhapkho/get/{id}") ?? new NhapKho();
        }
        public async Task<List<BaoCaoNhapKhoDate>> GetPhieuNhapByDateRange(NhapKhoDate dateRange)
        {
            var response = await _httpClient.PostAsJsonAsync("api/nhapkho/getbydaterange", dateRange);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<BaoCaoNhapKhoDate>>();
            }

            return new List<BaoCaoNhapKhoDate>();
        }
        public async Task<bool> DeleteNhapKho(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/nhapkho/delete/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateChiTietNhapKho(ChiTietNhapKhoCreate request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/nhapkho/chitiet/update", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi API: {ex.Message}");
                return false;
            }
        }

    }
}
