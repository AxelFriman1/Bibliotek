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
        public static void UserMainScreen()
        {
            Console.WriteLine("Startsida");
            Console.WriteLine("Vill du söka på en bok(1), låna en bok(2), ändra lösenord(3), eller logga ut(4)");
            int Input = Int32.Parse(Console.ReadLine());
            while(Input < 1 || Input > 4)
            {
                Console.WriteLine("Ej giltig input");
                Input = Int32.Parse(Console.ReadLine());
            }
            if (Input == 1)
            {
                ManageBooks.SearchBooks();
            }
            else if (Input == 2)
            {
                ManageBooks.BorrowBook();
            }
            else if(Input == 3)
            {
                ManageUser.ChangePassword();
                UserMainScreen();
            }
            else
            {
                LogOut();
            }
        }
        public static void LibrarianMainScreen()
        {
            Console.WriteLine("Lägg till användare(1), redigera en användare(2), ta bort en användare(3), lista alla medlemmar(4), lägg till en bok(5), radera en bok(6), redigera en bok(7), logga ut(8)");
            int Input = Int32.Parse(Console.ReadLine());
            while (Input < 1 || Input > 8)
            {
                Console.WriteLine("Ej giltig input");
                Input = Int32.Parse(Console.ReadLine());
            }
            if(Input == 1)
            {
                ManageUser.AddUser();
            }
            else if(Input == 2)
            {
                ManageUser.EditUser();
            }
            else if(Input == 3)
            {
                ManageUser.RemoveUser();
            }
            else if(Input == 4)
            {
                ManageUser.ListUsers();
            }
            else if(Input == 5)
            {
                ManageBooks.AddBook();
            }
            else if(Input == 6)
            {
                ManageBooks.DeleteBook();
            }
            else if(Input == 7)
            {
                ManageBooks.EditBook();
            }
            else
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
        
    }
}
