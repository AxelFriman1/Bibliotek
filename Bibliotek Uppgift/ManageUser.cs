using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bibliotek_Uppgift
{
    class ManageUser
    {
        private static string UserFirstName = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userFirstName.txt";
        private static string UserSurname = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSurname.txt";
        private static string UserSocialSecurityNumber = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userSocialSecurityNumber.txt";
        private static string UserPassword = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\userPassword.txt";
        public static void ChangePassword()
        {
            Console.WriteLine("Skriv in ditt gamla lösenord");
            string OldPassword = Console.ReadLine();
            Console.WriteLine("Skriv in ditt personnummer");
            string SocialSecurityNumber = Console.ReadLine();
            SocialSecurityNumber = LoginPage.CheckSSN(SocialSecurityNumber);

            if (LoginPage.AuthenticateLogin(SocialSecurityNumber, OldPassword) == true)
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
        public static void RemoveUser()
        {

            List<string> SSNList = new List<string>(File.ReadAllLines(UserSocialSecurityNumber));
            List<string> PasswordList = new List<string>(File.ReadAllLines(UserPassword));
            List<string> FirstNameList = new List<string>(File.ReadAllLines(UserFirstName));
            List<string> SurnameList = new List<string>(File.ReadAllLines(UserSurname));

            Console.Write("Skriv in personnummer på användare du vill ta bort: ");
            string SocialSecurityNumber = Console.ReadLine();
            int index = SSNList.FindIndex(a => a.Contains(SocialSecurityNumber));

            SSNList.RemoveAt(index);
            PasswordList.RemoveAt(index);
            FirstNameList.RemoveAt(index);
            SurnameList.RemoveAt(index);

            File.WriteAllLines(UserSocialSecurityNumber, SSNList);
            File.WriteAllLines(UserPassword, PasswordList);
            File.WriteAllLines(UserFirstName, FirstNameList);
            File.WriteAllLines(UserSurname, SurnameList);

            Console.WriteLine("Användare raderad!");
            Console.ReadLine();
            Console.Clear();
            MainPage.LibrarianMainScreen();
        }
        public static void EditUser()
        {
            List<string> SSNList = new List<string>(File.ReadAllLines(UserSocialSecurityNumber));

            Console.Write("Skriv in personnummer på användare du vill redigera: ");
            string SocialSecurityNumber = Console.ReadLine(); //KOLLA OM PERSONNUMMER EXISTERAR
         
            Console.WriteLine("Vill du ändra förnamn(1), efternamn(2), personnummer(3) eller lösenord(4)");
            int Input = Int32.Parse(Console.ReadLine());

            int Index = SSNList.FindIndex(a => a.Contains(SocialSecurityNumber));

            while (Input < 1 || Input > 4)
            {
                Console.WriteLine("Ej giltig input");
                Input = Int32.Parse(Console.ReadLine());
            }
            if(Input == 1)
            {
                UpdateFirstName(SocialSecurityNumber, Index);
            }
            else if(Input == 2)
            {

            }
            else if(Input == 3)
            {

            }
            else 
            {

            }
            Console.WriteLine("Användare uppdaterad");
            Console.ReadLine();
            Console.Clear();
            MainPage.LibrarianMainScreen();
        }
        public static void UpdateFirstName(string SocialSecurityNumber, int Index)
        {
            List<string> FirstNameList = new List<string>(File.ReadAllLines(UserFirstName));
            Console.Write("Skriv in nytt förnamn: ");
            string NewFirstName = Console.ReadLine();
            FirstNameList[Index] = NewFirstName;
            File.WriteAllLines(UserFirstName, FirstNameList);
        }
    }
}
