namespace NewProject.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime DateCreated = DateTime.Now;
        public string CharacterName { get; set; } = string.Empty;
    }
}
