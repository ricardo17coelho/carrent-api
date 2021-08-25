using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Domain;
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
        public Guid BrandId { get; set; }
        public CarBrand Brand { get; set; }
        [Required]
        public Guid TypeId { get; set; }
        public CarType Type { get; set; }
        public virtual ICollection<Reservation> Reservations {get; set;}
    }
}
