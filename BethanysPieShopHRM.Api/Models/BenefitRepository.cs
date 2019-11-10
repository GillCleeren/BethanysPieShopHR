using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public class BenefitRepository : IBenefitRepository
    {
        private readonly AppDbContext _appDbContext;

        public BenefitRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<BenefitModel> GetForEmployee(int employeeId)
        {
            var employeeBenefits = _appDbContext.EmployeeBenefits
                .Where(eb => eb.EmployeeId == employeeId);
            
            foreach (var benefit in _appDbContext.Benefits)
            {
                var employeeBenefit = employeeBenefits
                    .SingleOrDefault(eb => eb.BenefitId == benefit.BenefitId);

                yield return new BenefitModel
                {
                    BenefitId = benefit.BenefitId,
                    Selected = employeeBenefit != null,
                    Description = benefit.Description,
                    StartDate = employeeBenefit?.StartDate,
                    EndDate = employeeBenefit?.EndDate,
                    Premium = benefit.Premium
                };
            }      
        }

        public void UpdateForEmployee(int employeeId, IEnumerable<BenefitModel> model)
        {
            var existingBenefits = _appDbContext.EmployeeBenefits
                .Where(eb => eb.EmployeeId == employeeId);
            _appDbContext.RemoveRange(existingBenefits);

            var entities = model
                .Where(m => m.Selected)
                .Select(m => new EmployeeBenefit
            {
                BenefitId = m.BenefitId,
                EmployeeId = employeeId,
                StartDate = m.StartDate.Value,
                EndDate = m.EndDate.Value
            });
            _appDbContext.EmployeeBenefits.AddRange(entities);
            _appDbContext.SaveChanges();
        }
    }
}
