using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public List<User> users { get; set; }
        public Roles Name { get; set; }
    }
}
