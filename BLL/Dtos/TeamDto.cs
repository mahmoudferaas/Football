using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime FoundationDate { get; set; }
        public string CoachName { get; set; }
        public string LogoImage { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
    }
}
