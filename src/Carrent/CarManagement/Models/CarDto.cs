using Carrent.Common;
using Carrent.ReservationManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Api
{
    public class CarRequestCreateDto
    {
        public Guid BrandId { get; set; }
        public Guid TypeId { get; set; }
        public Guid ClassId { get; set; }
    }

    public class CarRequestEditDto
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public Guid TypeId { get; set; }
        public Guid ClassId { get; set; }
    }

    public class CarResponseDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public Guid BrandId { get; set; }
        public string Type { get; set; }
        public Guid TypeId { get; set; }
        public string Class { get; set; }
        public Guid ClassId { get; set; }
        public decimal PricePerDay { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
