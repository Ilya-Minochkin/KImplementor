using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class PositionRecord
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PositionRecordTypes Type { get; set; }
    }
}
