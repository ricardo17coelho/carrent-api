using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Carrent.Common.Interfaces;

namespace Carrent.CarManagement.Domain
{
    //public enum CarClassType
    //{
    //    Classic,
    //    Basic,
    //    Medium,
    //    Luxury
    //}
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
