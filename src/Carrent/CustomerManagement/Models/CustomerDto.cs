﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CustomerManagement.Models
{
    public interface ICustomerCreateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public Guid ZipId { get; set; }
    }

    public class CustomerEditDto : ICustomerCreateDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public Guid ZipId { get; set; }
    }
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public Guid ZipId { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Place { get; set; }
    }
}
