using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class BrandApiService
    {
        private readonly HttpClient _httpClient;

        public BrandApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BrandWithCarsDto> GetSingleBrandByIdWithCarAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<BrandWithCarsDto>>("brands/GetSingleBrandByIdWithCar");

            return response.Data;
        }

        public async Task<List<BrandDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<BrandDto>>>("brands");
            return response.Data;
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<BrandDto>>($"brands/{id}");
            return response.Data;

        }

        public async Task<BrandDto> SaveAsync(BrandDto newBrand)
        {
            var response = await _httpClient.PostAsJsonAsync("brands", newBrand);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<BrandDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(BrandDto newBrand)
        {
            var response = await _httpClient.PutAsJsonAsync("brands", newBrand);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"brands/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
