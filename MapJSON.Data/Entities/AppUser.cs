using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapJSON.Data.Entities
{
    public class AppUser
    { 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserSettings? UserSettings { get; set; }
        public ICollection<Trip> Trips { get; set; }
     }
}
