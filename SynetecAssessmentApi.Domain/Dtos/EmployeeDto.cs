﻿namespace SynetecAssessmentApi.Domain.Dtos
{
    public class EmployeeDto
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
