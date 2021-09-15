using FluentValidation;
using SynetecAssessmentApi.Domain.Dtos;

namespace SynetecAssessmentApi.Persistence.Validators
{
    public class CalculateBonusValidator: AbstractValidator<CalculateBonusDto>
    {
        public CalculateBonusValidator()
        {
            RuleFor(x => x.SelectedEmployeeId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.TotalBonusPoolAmount)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}