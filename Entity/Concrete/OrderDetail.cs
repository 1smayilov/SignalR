using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class OrderDetail : IEntity
    {
        public int OrderDetailId { get; set; }

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value; // buradakı value Countun dəyəridir (Set olduqda dəyər avtomatik _counta gedir)
                TotalPrice = _count * UnitPrice;
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get => _unitPrice;
            set
            {
                _unitPrice = value;
                TotalPrice = _unitPrice * Count;
            }
        }

        public decimal TotalPrice { get; private set; } // private set: çöldən dəyişilməsin

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
