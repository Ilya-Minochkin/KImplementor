namespace DataLayer.Entities
{
    public class Position
    {
        public long Id { get; set; }
        public Bill Bill { get; set; }
        public PositionRecord PositionRecord { get; set; }
        public double Quantity { get; set; }
        public double Sum { get; set; }
    }
}