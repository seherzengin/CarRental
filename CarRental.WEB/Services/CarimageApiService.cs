using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class CarimageApiService
    {
        private readonly HttpClient _httpClient;

        public CarimageApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarImageWithCarsDto> GetSingleCarimageByIdWithCarAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CarImageWithCarsDto>>("carimages/GetSingleCarimageByIdWithCar");

            return response.Data;
        }

        public async Task<CarImageDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CarImageDto>>($"carimages/{id}");
            return response.Data;

        }

        public async Task<CarImageDto> SaveAsync(CarImageDto newCarimage)
        {
            var response = await _httpClient.PostAsJsonAsync("carimages", newCarimage);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CarImageDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(CarImageDto newCarimage)
        {
            var response = await _httpClient.PutAsJsonAsync("carimages", newCarimage);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"carimages/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
