using System.Collections.Generic;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public interface IBenefitRepository
    {
        IEnumerable<BenefitModel> GetForEmployee(int employeeId);
        void UpdateForEmployee(int employeeId, IEnumerable<BenefitModel> model);
    }
}