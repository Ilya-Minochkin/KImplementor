using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PositionRecord
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PositionRecordTypes Type { get; set; }
    }
}
