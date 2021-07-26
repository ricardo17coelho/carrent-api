using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ZipCodeManagement.Models
{
    public class ZipCodeDto
    {
        public Guid Id { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
}
