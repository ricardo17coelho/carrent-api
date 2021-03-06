using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CustomerManagement.Models
{
    public class CustomerRequestCreateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }

    public class CustomerRequestEditDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
}
