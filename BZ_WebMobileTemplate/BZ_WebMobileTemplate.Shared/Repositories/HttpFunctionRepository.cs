using System.Text;
using System.Text.Json;
using BZ_WebMobileTemplate.Repositories.IRepository;
using BZ_WebMobileTemplate.Shared.Data;

namespace BZ_WebMobileTemplate.Shared.Repositories
{
    public class HttpFunctionRepository : IFunctionRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public HttpFunctionRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = "https://localhost:7101/api/functions"; // Update with your web app URL
        }

        public async Task<IEnumerable<UPRO_S_Function>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<UPRO_S_Function>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<UPRO_S_Function>();
        }

        public async Task<UPRO_S_Function?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
                
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UPRO_S_Function>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<UPRO_S_Function> CreateAsync(UPRO_S_Function function)
        {
            var json = JsonSerializer.Serialize(function);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();
            
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UPRO_S_Function>(responseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

        public async Task<UPRO_S_Function> UpdateAsync(UPRO_S_Function function)
        {
            var json = JsonSerializer.Serialize(function);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"{_baseUrl}/{function.FunctionId}", content);
            response.EnsureSuccessStatusCode();
            
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UPRO_S_Function>(responseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(responseJson);
            return result.GetProperty("success").GetBoolean();
        }
    }
}