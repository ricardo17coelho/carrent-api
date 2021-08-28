using Carrent.CarManagement.Domain;
using Carrent.Common.Interfaces;
using Carrent.CustomerManagement.Domain;
using Carrent.ReservationManagement.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carrent.ContractManagement.Domain
{
 
    public class RentalContract : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCosts { get; set; }
        public DateTime RentalDate { get; set; }
        [ForeignKey("ReservationID")]
        [Required]
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
