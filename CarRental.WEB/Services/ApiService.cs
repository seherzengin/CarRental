using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<T>> GetAllAsync<T>(string url) where T : class
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<T>>>(url);
            return response.Data;
        }

        public async Task<T> GetByIdAsync<T>(string url) where T : class
        {
            dynamic response = await _httpClient.GetFromJsonAsync<CustomResponseDto<T>>(url);
            return response.Data;
        }

        public async Task<bool> RemoveAsync(string url)
        {
            dynamic response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<T> SaveAsync<T>(string url, T data) where T : class
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            if (response.IsSuccessStatusCode)
            {
                dynamic responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<T>>();
                return responseBody.Data;
            }
            return null;
        }

        public async Task<bool> UpdateAsync<T>(string url, T data) where T : class
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            return response.IsSuccessStatusCode;
        }
    }
}
