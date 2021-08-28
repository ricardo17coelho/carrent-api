using System;

namespace Carrent.ContractManagement.Models
{
    public class RentalContractRequestCreateDto
    {
        public DateTime RentalDate { get; set; }
        public Guid ReservationId { get; set; }
        public decimal TotalCosts { get; set; }
    }

    public class RentalContractRequestEditDto
    {
        public Guid Id { get; set; }
        public DateTime RentalDate { get; set; }
        public Guid ReservationId { get; set; }
    }
    public class RentalContractResponseDto
    {
        public Guid Id { get; set; }
        public decimal TotalCosts { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ReservationId { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
    }
}
