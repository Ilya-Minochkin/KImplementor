using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KImplementor.Models
{
    public class BillModel
    {
        public Bill Bill { get; set; }
        public double Sum => Bill.Positions.Sum(x => x.Sum);
        public bool IsPaid => Bill.Payment == 0;
        public bool IsShipped => Bill.Shipment == 0;
    }
}
