﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientBookStoreApp.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Status { get; set; } = "Activo";
    }
}
