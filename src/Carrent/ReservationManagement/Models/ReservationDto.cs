using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ReservationManagement.Models
{
    public class ReservationRequestCreateDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
    }
    public class ReservationRequestEditDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
    }
    public class ReservationResponseDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalDays { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public Guid CarId { get; set; }
        public string CarName { get; set; }
        public decimal TotalCost { get; set; }
    }
}
