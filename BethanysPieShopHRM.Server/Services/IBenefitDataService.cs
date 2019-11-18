using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IBenefitDataService
    {
        Task<IEnumerable<BenefitModel>> GetForEmployee(EmployeeModel employee);
        Task UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitModel> benefits);
    }
}