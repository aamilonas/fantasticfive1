namespace fantasticfive1.Models
{
    public class HousingModel
    {
        // String properties
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ShelterType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? hours { get; set; }

        // Boolean properties
        public int Womens { get; set; }
        public int ChildFriendly { get; set; }
        public int AllWelcome { get; set; }
        public int PetFriendly { get; set; }
    }
}
