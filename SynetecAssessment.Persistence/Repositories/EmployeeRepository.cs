using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Repositories;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
        public Task<Employee> GetByIdWithDepartment(long employeeId)
        {
            return _context.Employees
                .AsNoTracking()
                .Where(w => w.Id == employeeId)
                .Include(i => i.Department)
                .FirstOrDefaultAsync();
        }
        
        public IEnumerable<Employee> GetList()
        {
            return _context.Employees
                .AsNoTracking()
                .OrderBy(o => o.Fullname);
        }
        public IEnumerable<Employee> GetListWithDepartments()
        {
            return _context.Employees
                .AsNoTracking()
                .Include(i => i.Department)
                .OrderByDescending(o => o.Fullname);
        }
        
        public Task<decimal> GetTotalSalary()
        {
            return _context.Employees
                .SumAsync(s => s.Salary);
        }
    }
}