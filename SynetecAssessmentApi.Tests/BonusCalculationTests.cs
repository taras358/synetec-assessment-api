using System.Threading.Tasks;
using Moq;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Repositories;
using SynetecAssessmentApi.Domain.Services;
using Xunit;

namespace SynetecAssessmentApi.Tests
{
    public class BonusCalculationTests
    {
        [Fact]
        public async Task IndexViewDataMessage()
        {
            var requestModel = new CalculateBonusDto
            {
                TotalBonusPoolAmount = 87654,
                SelectedEmployeeId = 1
            };

            var employee = new Employee
            {
                Id = 1, 
                Fullname = "John Smith", 
                JobTitle = "Accountant (Senior)",
                Salary = 50000, 
                DepartmentId = 1,
                Department = new Department
                {
                    Id = 1, 
                    Title =  "Finance",
                    Description= "The finance department for the company"
                }
            };
            
            var totalSalary = 123456M;
            var actualResult = 35500.10M;
            var employeeRepository = new Mock<IEmployeeRepository>();
            
            employeeRepository.Setup(x => 
                x.GetByIdWithDepartment(requestModel.SelectedEmployeeId))
                .Returns(Task.FromResult(employee));
            employeeRepository.Setup(x => 
                x.GetTotalSalary())
                .Returns(Task.FromResult(totalSalary));

            var financeService = new BonusPoolService(employeeRepository.Object);
            var result = await financeService.CalculateAsync(requestModel);

            Assert.Equal(result.Amount, actualResult);
        }
    }
}