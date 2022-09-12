using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class CarApiService
    {
        private readonly HttpClient _httpClient;

        public CarApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CarDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CarDto>>>("cars");
            return response.Data;
        }

        public async Task<CarDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CarDto>>($"cars/{id}");
            return response.Data;

        }

        public async Task<CarDto> SaveAsync(CarDto newCar)
        {
            var response = await _httpClient.PostAsJsonAsync("cars", newCar);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CarDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(CarDto newCar)
        {
            var response = await _httpClient.PutAsJsonAsync("cars", newCar);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cars/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
