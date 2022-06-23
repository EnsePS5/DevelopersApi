using System;
using System.Collections.Generic;

namespace DevelopersApi.Entities_Models
{
    public class Game
    {
        public int IdGame { get; set; }
        public string Name { get; set; }
        public DateTime RealeseDate { get; set; }
        public byte NeedVrImplement { get; set; }


        public virtual ICollection<DeveloperGame> DeveloperGames { get; set; }


        public Game() {

            DeveloperGames = new HashSet<DeveloperGame>();
        }
    }
}