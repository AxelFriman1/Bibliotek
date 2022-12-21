using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotek_Uppgift
{
    public class User
    {
        public string Title;
        public string FirstName;
        public string Surname;
        public string SocialSecurityNumber;

        public User(string Title, string FirstName, string Surname, string SocialSecurityNumber)
        {
            this.Title = Title;
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.SocialSecurityNumber = SocialSecurityNumber;
        }
    }
}
