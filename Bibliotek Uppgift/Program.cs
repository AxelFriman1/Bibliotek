using System;
using System.IO;
using System.Linq;

namespace Bibliotek_Uppgift
{
    class Program
    {
        private static string UserFirstName = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userFirstName.txt";
        private static string UserSurname = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSurname.txt";
        private static string UserSocialSecurityNumber = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSocialSecurityNumber.txt";
        private static string UserPassword = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userPassword.txt";
        static void Main(string[] args)
        {
            LoginOrSignUp();
            
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
            Console.WriteLine("Skriv in ditt personnummer");
            string SSNInput = Console.ReadLine(); //(Social Security Number)
            Console.WriteLine("Skriv in ditt lösenord");
            string PasswordInput = Console.ReadLine();
            if(CheckLogin(SSNInput, PasswordInput) == true)
            {

            }
            else
            {
                Console.WriteLine("Inloggningsuppgifter stämde inte!");
                LoginOrSignUp();
            }
        }
        public static bool CheckLogin(string SocialSecurityNumber, string Password)
        {
            string[] SSNArray = File.ReadAllLines(UserSocialSecurityNumber);
            string[] PasswordArray = File.ReadAllLines(UserPassword);
            int SSNIndex = Array.IndexOf(SSNArray, SocialSecurityNumber);
            if(SocialSecurityNumber == SSNArray[SSNIndex] && Password == PasswordArray[SSNIndex])
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
            while(SocialSecurityNumber.Length != 10)
            {
                Console.WriteLine("Personnummret ska vara 10 siffror långt");
                SocialSecurityNumber = Console.ReadLine();
            }
            Console.WriteLine("Lösenord: ");
            string Password = Console.ReadLine();
            Console.WriteLine("Du har registrerat dig!");

            User user = new User(FirstName, Surname, SocialSecurityNumber, Password);
            File.AppendAllText(UserFirstName, user.FirstName + Environment.NewLine);
            File.AppendAllText(UserSurname, user.Surname+ Environment.NewLine);
            File.AppendAllText(UserSocialSecurityNumber, user.SocialSecurityNumber + Environment.NewLine);
            File.AppendAllText(UserPassword, user.Password + Environment.NewLine);
            LoginOrSignUp();
        }
    }
}
