using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Api
{
    public class CarClassRequestCreateDto
    {
        public string Type { get; set; }
        public decimal PricePerDay { get; set; }
    }
    public class CarClassRequestEditDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal PricePerDay { get; set; }
    }
    public class CarClassResponseDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
