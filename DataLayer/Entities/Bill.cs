using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Bill
    {
        public long Id { get; set; }
        public Organization Client { get; set; }
        public List<Position> Positions { get; set; }
        public DateTime Date { get; set; }
        public User Owner { get; set; }
        public double Payment { get; set; }
        public double Shipment { get; set; }
    }
}
