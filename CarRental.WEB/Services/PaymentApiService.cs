using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class PaymentApiService
    {
        private readonly HttpClient _httpClient;

        public PaymentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PaymentDto>>>("payments");
            return response.Data;
        }

        public async Task<PaymentDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PaymentDto>>($"payments/{id}");
            return response.Data;

        }

        public async Task<PaymentDto> SaveAsync(PaymentDto newPayment)
        {
            var response = await _httpClient.PostAsJsonAsync("payments", newPayment);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<PaymentDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(PaymentDto newPayment)
        {
            var response = await _httpClient.PutAsJsonAsync("payments", newPayment);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"payments/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
