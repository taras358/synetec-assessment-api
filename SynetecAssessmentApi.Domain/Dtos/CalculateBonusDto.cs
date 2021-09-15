namespace SynetecAssessmentApi.Domain.Dtos
{
    public class CalculateBonusDto
    {
        public decimal TotalBonusPoolAmount { get; set; }
        public long SelectedEmployeeId { get; set; }
    }
}
