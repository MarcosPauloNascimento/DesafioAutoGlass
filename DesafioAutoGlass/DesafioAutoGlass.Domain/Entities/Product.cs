﻿using DesafioAutoGlass.Domain.Enum;
using System;

namespace DesafioAutoGlass.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
