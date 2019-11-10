using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployees();
        Task<EmployeeModel> GetEmployeeDetails(int employeeId);
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployee(int employeeId);
    }
}
