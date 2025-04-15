﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.OrderDetailDto
{
    public class CreateOrderDetailDto
    {
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
