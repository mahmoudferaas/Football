using System;

namespace DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public Team Team { get; set; }
    }
}
