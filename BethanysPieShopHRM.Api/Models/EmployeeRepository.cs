using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return _appDbContext.Employees
                .Include(e => e.EmployeeBenefits).ThenInclude(eb => eb.Benefit)
                .Select(e => e.ToModel());
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employees
                .FirstOrDefault(c => c.EmployeeId == employeeId)
                .ToModel();
        }

        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            var newEmployee = new Employee();
            employeeModel.UpdateEntity(newEmployee);
            var addedEntity = _appDbContext.Employees.Add(newEmployee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity.ToModel();
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel)
        {
            var foundEmployee = _appDbContext.Employees
                .FirstOrDefault(e => e.EmployeeId == employeeModel.EmployeeId);

            if (foundEmployee != null)
            {
                employeeModel.UpdateEntity(foundEmployee);
                _appDbContext.SaveChanges();
                return foundEmployee.ToModel();
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
