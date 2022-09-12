using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class ColorApiService
    {
        private readonly HttpClient _httpClient;

        public ColorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ColorWithCarsDto> GetSingleColorByIdWithCarAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ColorWithCarsDto>>("colors/GetSingleColorByIdWithCar");

            return response.Data;
        }

        public async Task<List<ColorDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ColorDto>>>("colors");
            return response.Data;
        }
    }
}
