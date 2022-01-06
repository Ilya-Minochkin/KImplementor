using DataLayer.Enums;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public List<User> Users { get; set; }
        public Roles Name { get; set; }
    }
}
