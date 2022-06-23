namespace DevelopersApi.Entities_Models
{
    public class DeveloperGame
    {

        public int IdDeveloper { get; set; }
        public int IdGame { get; set; }
        public string Role { get; set;}


        public virtual Developer IdDeveloperNavigation { get; set; }
        public virtual Game IdGameNavigation { get; set; }

    }
}