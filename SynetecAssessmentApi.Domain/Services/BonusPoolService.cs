using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Constants;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Exceptions;
using SynetecAssessmentApi.Domain.Repositories;
using SynetecAssessmentApi.Domain.Services.Interfaces;

namespace SynetecAssessmentApi.Domain.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public BonusPoolService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public IEnumerable<EmployeeDto> GetEmployeesAsync()
        {
            var employees = _employeeRepo.GetListWithDepartments();

            return employees.Select(employee => 
                new EmployeeDto
                {
                    Fullname = employee.Fullname, 
                    JobTitle = employee.JobTitle, 
                    Salary = employee.Salary, 
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                }).ToList();
        }

        public async Task<BonusPoolCalculatorResultDto> CalculateAsync(CalculateBonusDto result)
        {
            //load the details of the selected employee using the Id
            Employee employee = await _employeeRepo.GetByIdWithDepartment(result.SelectedEmployeeId);

            if (employee is null)
            {
                throw new AppException(AppConstant.NOT_FOUND, HttpStatusCode.BadRequest);
            }

            //get the total salary budget for the company
            var totalSalary = await _employeeRepo.GetTotalSalary();
            //calculate the bonus allocation for the employee
            var bonusPercentage = employee.Salary / totalSalary;
            var bonusAllocation = decimal.Round(bonusPercentage * result.TotalBonusPoolAmount, 2);

            return new BonusPoolCalculatorResultDto
            {
                Employee = new EmployeeDto
                {
                    Fullname = employee.Fullname,
                    JobTitle = employee.JobTitle,
                    Salary = employee.Salary,
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                },
                Amount = bonusAllocation
            };
        }
    }
}
