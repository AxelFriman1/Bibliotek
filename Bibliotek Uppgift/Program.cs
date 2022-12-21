using System;
using System.IO;
using System.Linq;

namespace Bibliotek_Uppgift
{
    class Program
    {
        private static string UserTitle = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userTitle.txt";
        private static string UserFirstName = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userFirstName.txt";
        private static string UserSurname = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSurname.txt";
        private static string UserSocialSecurityNumber= @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSocialSecurityNumber.txt";
        static void Main(string[] args)
        {
            LoginOrSignUp();
            Console.ReadLine();
        }

        public static void LoginOrSignUp()
        {
            Console.WriteLine("Skriv 'logga in' om du vill logga in  eller 'registrera' om du vill registrera dig");
            string Input = Console.ReadLine();
            while(Input != "logga in" && Input != "registrera")
            {
                Console.WriteLine("Du skrev fel");
                Input = Console.ReadLine();
            }
            if(Input == "registrera")
            {
                SignUp();
            }
            else
            {
                Login();
            }

        }
        public static void Login()
        {

        }
        public static void SignUp()
        {
            Console.WriteLine("Skriv 'medlem' för att registrera dig som medlem eller 'bibliotekarie' för att registrera dig som bibliotekarie");
            string Title = Console.ReadLine();
            while(Title != "medlem" && Title != "bibliotekarie")
            {
                Console.WriteLine("Du skrev fel");
                Title = Console.ReadLine();
            }
            Console.WriteLine("Förnamn: ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Efternamn: ");
            string Surname = Console.ReadLine();
            Console.WriteLine("Personnummer(ÅÅMMDDNNNC): ");
            string SocialSecurityNumber = Console.ReadLine();
            while(SocialSecurityNumber.Length != 10)
            {
                Console.WriteLine("Personnummret ska vara 10 siffror långt");
                SocialSecurityNumber = Console.ReadLine();
            }

            User user = new User(Title, FirstName, Surname, SocialSecurityNumber);
            File.AppendAllText(UserTitle, user.Title + Environment.NewLine);
            File.AppendAllText(UserFirstName, user.FirstName + Environment.NewLine);
            File.AppendAllText(UserSurname, user.Surname+ Environment.NewLine);
            File.AppendAllText(UserSocialSecurityNumber, user.SocialSecurityNumber + Environment.NewLine);
        }

        
    }
}
