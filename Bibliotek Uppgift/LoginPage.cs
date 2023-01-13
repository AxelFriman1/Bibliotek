using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bibliotek_Uppgift
{
    public class LoginPage
    {
        private static string UserFirstName = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userFirstName.txt";
        private static string UserSurname = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSurname.txt";
        private static string UserSocialSecurityNumber = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSocialSecurityNumber.txt";
        private static string UserPassword = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userPassword.txt";
        public static void StartPage()
        {
            LoginOrSignUp();
        }

        public static void LoginOrSignUp()
        {
            Console.WriteLine("Skriv 'logga in' om du vill logga in  eller 'registrera' om du vill registrera dig");
            string Input = Console.ReadLine();
            while (Input != "logga in" && Input != "registrera")
            {
                Console.WriteLine("Du skrev fel.");
                Input = Console.ReadLine();
            }
            if (Input == "registrera")
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
            Console.WriteLine("Skriv in ditt personnummer");
            string SSNInput = Console.ReadLine(); //(Social Security Number)
            Console.WriteLine("Skriv in ditt lösenord");
            string PasswordInput = Console.ReadLine();
            if (AuthenticateLogin(SSNInput, PasswordInput) == true)
            {

            }
            else
            {
                Console.WriteLine("Inloggningsuppgifter stämde inte!");
                Console.ReadLine();
                Console.Clear();
                LoginOrSignUp();
            }
        }
        public static bool AuthenticateLogin(string SocialSecurityNumber, string Password)
        {
            string[] SSNArray = File.ReadAllLines(UserSocialSecurityNumber);
            string[] PasswordArray = File.ReadAllLines(UserPassword);
            int SSNIndex = Array.IndexOf(SSNArray, SocialSecurityNumber); //Tar indexen av förekommandet av "SocialSecurityNumber"
            if (SocialSecurityNumber == SSNArray[SSNIndex] && Password == PasswordArray[SSNIndex])
            {
                return true;
            }
            return false;
        }
        public static void SignUp()
        {
            Console.WriteLine("Förnamn: ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Efternamn: ");
            string Surname = Console.ReadLine();
            Console.WriteLine("Personnummer(ÅÅMMDDNNNC): ");
            string SocialSecurityNumber = Console.ReadLine();
            while (SocialSecurityNumber.Length != 10)
            {
                Console.WriteLine("Personnummret ska vara 10 siffror långt");
                SocialSecurityNumber = Console.ReadLine();
            }
            Console.WriteLine("Lösenord: ");
            string Password = Console.ReadLine();
            Console.WriteLine("Du har registrerat dig!");
            Console.ReadLine();
            Console.Clear();

            User user = new User(FirstName, Surname, SocialSecurityNumber, Password);
            File.AppendAllText(UserFirstName, user.FirstName + Environment.NewLine);
            File.AppendAllText(UserSurname, user.Surname + Environment.NewLine);
            File.AppendAllText(UserSocialSecurityNumber, user.SocialSecurityNumber + Environment.NewLine);
            File.AppendAllText(UserPassword, user.Password + Environment.NewLine);
            LoginOrSignUp();

        }
    }
}
