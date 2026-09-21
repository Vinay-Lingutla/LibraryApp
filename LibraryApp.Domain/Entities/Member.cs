using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entities
{
    public class Member: BaseEntity
    {
        
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public Member(string Name, string Email, string Password)
        {
            if(string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            if(string.IsNullOrEmpty(Email))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }
            if(string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;

        }
    }
}
