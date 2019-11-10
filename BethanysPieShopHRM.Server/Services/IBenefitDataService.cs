using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IBenefitDataService
    {
        Task<IEnumerable<BenefitModel>> GetForEmployee(int id);
        Task UpdateForEmployee(int employeeId, IEnumerable<BenefitModel> benefits);
    }
}