using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Server.Services
{
    public class BenefitDataService : IBenefitDataService
    {
        private readonly HttpClient _httpClient;

        public BenefitDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BenefitModel>> GetForEmployee(EmployeeModel employee)
        {
            return await JsonSerializer.DeserializeAsync<List<BenefitModel>>
                (await _httpClient.GetStreamAsync($"api/benefit/{employee.EmployeeId}"), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitModel> benefits)
        {
            var benefitJson =
                new StringContent(JsonSerializer.Serialize(benefits), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"api/benefit/{employee.EmployeeId}", benefitJson);
        }
    }
}
