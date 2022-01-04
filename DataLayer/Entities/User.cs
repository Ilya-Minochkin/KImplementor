namespace DataLayer.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}