using Carrent.ReservationManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Domain
{
    public class Car
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        public CarClass Class { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        public virtual ICollection<Reservation> Reservations {get; set;}
    }
}
