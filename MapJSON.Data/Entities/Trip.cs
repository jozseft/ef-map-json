using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapJSON.Data.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FinalDestination { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<TransitDetail>? Transits { get; set; }
    }
}
