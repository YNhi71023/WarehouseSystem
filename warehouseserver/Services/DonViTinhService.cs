using System.Net.Http.Json;
using warehouseserver.Models;

namespace warehouseserver.Services
{
    public class DonViTinhService
    {
        private readonly HttpClient _httpClient;

        public DonViTinhService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DonViTinh>> GetAllDonViTinh()
        {
            return await _httpClient.GetFromJsonAsync<List<DonViTinh>>("api/donvitinh/getall");
        }

        //public async Task<string> CreateDonViTinh(DonViTinh donViTinh)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/donvitinh/create", donViTinh);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var errorMessage = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine($"Lỗi API: {errorMessage}");
        //        return "Lỗi khi gọi API.";
        //    }

        //    var result = await response.Content.ReadFromJsonAsync<ResponseMessage>();
        //    return result?.Message ?? "Tạo mới thành công!";
        //}
        public async Task<DonViTinh> GetDonViTinhById(int id)
        {
            return await _httpClient.GetFromJsonAsync<DonViTinh>($"api/donvitinh/get/{id}") ?? new DonViTinh();
        }

        public async Task<bool> UpdateDonViTinh(DonViTinh donViTinh)
        {
            var response = await _httpClient.PutAsJsonAsync("api/donvitinh/update", donViTinh);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteDonViTinh(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/donvitinh/delete/{id}");
            return response.IsSuccessStatusCode;
        }


    }

    public class ResponseMessage
    {
        public string Message { get; set; }
    }
}
