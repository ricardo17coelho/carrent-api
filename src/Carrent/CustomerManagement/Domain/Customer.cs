
using Carrent.Common.Interfaces;
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
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Town { get; set; }
    }
}
