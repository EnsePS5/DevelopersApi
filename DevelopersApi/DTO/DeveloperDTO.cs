using System;

namespace DevelopersApi
{
    public class DeveloperDTO
    {
        public int IdDeveloper { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfJoin { get; set; }
    }
}