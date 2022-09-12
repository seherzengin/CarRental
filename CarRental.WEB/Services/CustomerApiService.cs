using CarRental.Core.DTOs;

namespace CarRental.WEB.Services
{
    public class CustomerApiService
    {
        private readonly HttpClient _httpClient;

        public CustomerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /*public async Task<CustomerWithUserDto> GetSingleCustomerByIdWithUserAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CustomerWithUserDto>>("customers/GetSingleCustomerByIdWithUser");

            return response.Data;
        }*/

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CustomerDto>>>("customers");
            return response.Data;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CustomerDto>>($"customers/{id}");
            return response.Data;

        }

        public async Task<CustomerDto> SaveAsync(CustomerDto newCustomer)
        {
            var response = await _httpClient.PostAsJsonAsync("customers", newCustomer);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CustomerDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(CustomerDto newCustomer)
        {
            var response = await _httpClient.PutAsJsonAsync("customers", newCustomer);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"customers/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
