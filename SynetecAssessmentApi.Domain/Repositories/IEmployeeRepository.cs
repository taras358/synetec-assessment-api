using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Entities;

namespace SynetecAssessmentApi.Domain.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetByIdWithDepartment(long employeeId);
        IEnumerable<Employee> GetListWithDepartments();
        Task<decimal> GetTotalSalary();
    }
}