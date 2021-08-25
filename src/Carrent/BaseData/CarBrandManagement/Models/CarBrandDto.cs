using System;

namespace Carrent.BaseData.CarBrandManagement.Models
{
    public class CarBrandRequestCreateDto
    {
        public string Title { get; set; }
    }

    public class CarBrandRequestEditDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

    public class CarBrandResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
