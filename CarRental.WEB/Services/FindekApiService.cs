using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class FindekApiService
    {
        private readonly HttpClient _httpClient;

        public FindekApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FindekDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<FindekDto>>>("findeks");
            return response.Data;
        }

        public async Task<FindekDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<FindekDto>>($"findeks/{id}");
            return response.Data;

        }

        public async Task<FindekDto> SaveAsync(FindekDto newFindek)
        {
            var response = await _httpClient.PostAsJsonAsync("findeks", newFindek);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<FindekDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(FindekDto newFindek)
        {
            var response = await _httpClient.PutAsJsonAsync("findeks", newFindek);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"findeks/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
