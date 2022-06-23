using System;
using System.Collections.Generic;

namespace DevelopersApi.Entities_Models
{
    public class Developer
    {
        public int IdDeveloper { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfJoin { get; set; }


        public virtual ICollection<DeveloperGame> DeveloperGames { get; set; }

        public Developer() {

            DeveloperGames = new HashSet<DeveloperGame>();
        }
        
    }
}