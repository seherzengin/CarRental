using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class CreditcardApiService
    {
        private readonly HttpClient _httpClient;

        public CreditcardApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreditcardWithUserDto> GetSingleCreditcardByIdWithUserAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CreditcardWithUserDto>>("creditcards/GetSingleCreditcardByIdWithUser");

            return response.Data;
        }
        public async Task<List<CreditcardDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CreditcardDto>>>("creditcards");
            return response.Data;
        }

        public async Task<CreditcardDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CreditcardDto>>($"creditcards/{id}");
            return response.Data;

        }

        public async Task<CreditcardDto> SaveAsync(CreditcardDto newCreditcard)
        {
            var response = await _httpClient.PostAsJsonAsync("creditcards", newCreditcard);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CreditcardDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(CreditcardDto newCreditcard)
        {
            var response = await _httpClient.PutAsJsonAsync("creditcards", newCreditcard);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"creditcards/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
