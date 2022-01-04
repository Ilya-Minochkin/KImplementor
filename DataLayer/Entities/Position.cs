namespace DataLayer.Entities
{
    public class Position
    {
        public long Id { get; set; }
        public long? BillId { get; set; }
        public long? PositionRecordId { get; set; }
        public double Quantity { get; set; }
        public double Sum { get; set; }
    }
}