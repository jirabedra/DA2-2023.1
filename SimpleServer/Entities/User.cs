namespace Entities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Validate()
        {
            if(FirstName == "" || LastName == "") {
                throw new ArgumentException("Nombre vacio");
            }
        }
    }
}