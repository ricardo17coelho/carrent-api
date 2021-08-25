using System;

namespace Carrent.BaseData.CarTypeManagement.Models
{
    public class CarTypeRequestCreateDto
    {
        public string Title { get; set; }
    }

    public class CarTypeRequestEditDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

    public class CarTypeResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
