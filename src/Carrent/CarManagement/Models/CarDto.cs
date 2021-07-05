﻿using Carrent.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Api
{
    public class CarDto : IDataDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public Guid ClassId { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
