﻿namespace Entities
{
    public class User
    {
        public int Id { get; set; }
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