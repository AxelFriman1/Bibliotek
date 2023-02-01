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
            Console.Write("Skriv in ditt personnummer: ");
            string SSNInput = Console.ReadLine(); //(Social Security Number)
            SSNInput = CheckSSN(SSNInput);
            Console.Write("Skriv in ditt lösenord: ");
            string PasswordInput = Console.ReadLine();
            if (AuthenticateLogin(SSNInput, PasswordInput) == true)
            {
                Console.Clear();
                MainPage.MainScreen();
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
            int SSNIndex = Array.IndexOf(SSNArray, SocialSecurityNumber); //Tar indexen för förekommandet av "SocialSecurityNumber"
            if(SSNIndex > -1) //Om SocialSecurityNumber inte finns i arrayen så blir indexet -1
            {
                if (Password == PasswordArray[SSNIndex])
                {
                    return true;
                }
            }
            return false;
        }
        public static void SignUp()
        {
            Console.Write("Förnamn: ");
            string FirstName = Console.ReadLine();
            Console.Write("Efternamn: ");
            string Surname = Console.ReadLine();
            Console.Write("Personnummer(ÅÅMMDDNNNC): ");
            string SocialSecurityNumber = Console.ReadLine();
            SocialSecurityNumber = CheckSSN(SocialSecurityNumber);
            if(CheckDuplicateSSN(SocialSecurityNumber))
            {
                Console.WriteLine("Ditt personnummer är redan registrerat!");
                Console.ReadLine();
                Console.Clear();
                LoginOrSignUp();
                return;
            }
            Console.Write("Lösenord: ");
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
        public static string CheckSSN(string SocialSecurityNumber)
        {
            while (SocialSecurityNumber.Length != 10)
            {
                Console.WriteLine("Personnummret ska vara 10 siffror långt");
                SocialSecurityNumber = Console.ReadLine();
            }
            return SocialSecurityNumber;
        }
        public static bool CheckDuplicateSSN(string SocialSecurityNumber)
        {
            string[] SSNArray = File.ReadAllLines(UserSocialSecurityNumber);
            
            for (int i = 0; i < SSNArray.Length; i++)
            {
                if(SocialSecurityNumber == SSNArray[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static void ChangePassword()
        {
            Console.WriteLine("Skriv in ditt gamla lösenord");
            string OldPassword = Console.ReadLine();
            Console.WriteLine("Skriv in ditt personnummer");
            string SocialSecurityNumber = Console.ReadLine();
            SocialSecurityNumber = CheckSSN(SocialSecurityNumber);

            if(AuthenticateLogin(SocialSecurityNumber, OldPassword) == true)
            {
                Console.WriteLine("Skriv in ditt nya lösenord");
                string NewPassword = Console.ReadLine();
                string text = File.ReadAllText(UserPassword);
                text = text.Replace(OldPassword, NewPassword);
                File.WriteAllText(UserPassword, text);
                Console.WriteLine("Du har bytt lösenord!");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Lösenord och personnummer stämde inte!");
                Console.ReadLine();
                Console.Clear();
            }
            

            
        }
    }
}
