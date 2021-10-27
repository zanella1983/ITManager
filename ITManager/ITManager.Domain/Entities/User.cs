namespace ITManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        public User(string name, string lastName, string email, string password, bool active)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Active = active;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
    }
}
