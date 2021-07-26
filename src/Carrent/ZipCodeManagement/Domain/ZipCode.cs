using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ZipCodeManagement.Domain
{
    public class ZipCode : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        [Required]
        public string Town { get; set; }
    }
}
