
using Carrent.Common.Interfaces;
using Carrent.ZipCodeManagement.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Carrent.CustomerManagement.Domain
{
    public class Customer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public Guid ZipId { get; set; }
        public ZipCode Zip { get; set; }
    }
}
