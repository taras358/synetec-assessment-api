using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Dtos;

namespace SynetecAssessmentApi.Domain.Services.Interfaces
{
    public interface IBonusPoolService
    {
        IEnumerable<EmployeeDto> GetEmployeesAsync();
        Task<BonusPoolCalculatorResultDto> CalculateAsync(CalculateBonusDto result);
    }
}