using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime FoundationDate { get; set; }
        public string CoachName { get; set; }
        public string LogoImage { get; set; }
        public virtual IEnumerable<Player> Players { get; set; }
    }
}
