﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = String.Empty;
    }
}
