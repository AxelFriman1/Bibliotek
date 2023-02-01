using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotek_Uppgift
{
    public class MainPage
    {
        private static string BookTitle = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\BookTitle.txt";
        private static string BookAuthor = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\BookAuthor.txt";
        private static string BookGenre = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\BookGenre.txt";
        private static string BookISBN = @"C:\Users\axel.friman\Desktop\Bibliotek Uppgift\Bibliotek Uppgift\BookISBN.txt";
        public static void MainScreen()
        {
            Console.WriteLine("Startsida");
            Console.WriteLine("Vill du söka på en bok(1), kolla på dina lånade böcker(2), ändra lösenord(3), eller logga ut(4)");
            int Input = Int32.Parse(Console.ReadLine());
            while(Input < 1 || Input > 4)
            {
                Console.WriteLine("Ej giltig input");
                Input = Int32.Parse(Console.ReadLine());
            }
            if (Input == 1)
            {
               
            }
            else if (Input == 2)
            {
                CheckInventory();
            }
            else if(Input == 3)
            {
                LoginPage.ChangePassword();
                MainScreen();
            }
            else if(Input == 4)
            {
                LogOut();
            }
        }
        public static void LogOut()
        {
            Console.Clear();
            Console.WriteLine("Du har loggat ut!");
            Console.ReadLine();
            Console.Clear();
            LoginPage.StartPage();
        }
        public static void CheckInventory()
        {

        }
        public static void SearchBooks()
        {

        }
        
    }
}
