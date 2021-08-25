using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carrent.Common.Interfaces;

namespace Carrent.BaseData.CarClassManagement.Domain
{
    public class CarClass : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerDay { get; set; }
    }
}
