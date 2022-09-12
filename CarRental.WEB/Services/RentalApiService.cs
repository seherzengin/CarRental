using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class RentalApiService
    {
        private readonly HttpClient _httpClient;

        public RentalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RentalDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<RentalDto>>>("rentals");
            return response.Data;
        }

        public async Task<RentalDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<RentalDto>>($"rentals/{id}");
            return response.Data;

        }

        public async Task<RentalDto> SaveAsync(RentalDto newRental)
        {
            var response = await _httpClient.PostAsJsonAsync("rentals", newRental);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<RentalDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(RentalDto newRental)
        {
            var response = await _httpClient.PutAsJsonAsync("rentals", newRental);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"rentals/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
