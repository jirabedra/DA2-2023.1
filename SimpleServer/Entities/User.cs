namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Timestamp { get; set; }

        public void Validate()
        {
            if(FirstName == "" || LastName == "") {
                throw new ArgumentException("Nombre vacio");
            }
        }
    }
}