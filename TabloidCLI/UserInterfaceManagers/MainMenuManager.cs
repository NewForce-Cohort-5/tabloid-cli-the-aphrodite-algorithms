using System;

namespace TabloidCLI.UserInterfaceManagers
{
    public class MainMenuManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING = 
            @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine(@"
                    __  __     ____    
    _     _        / / / ___  / / ____    |   
  o' \,=./ `o     / /_/ / _ \/ / / __ \   |.===.
     (o o)       / __  /  __/ / / /_/ /   {}o o{}
-ooO--(_)--Ooo- /_/ /_/\___/_/_/\____/ ooO--(_)--Ooo-
            ");

   //         Console.WriteLine(@"
   //   _     _   
   //  (c).-.(c)     __ __   ___ _     _      ___  
   //   / ._. \     |  T  T /  _| T   | T    /   \
   // __\( Y )/__   |  l  |/  [_| |   | |   Y     Y 
   //(_.-/'-'\-._)  |  _  Y    _| l___| l___|  O  | 
   //   || o ||     |  |  |   [_|     |     |     | 
   // _.' `-' '._   |  |  |     |     |     l     ! 
   //(.-./`-'\.-.)  l__j__l_____l_____l_____j\___/ 
   // `-'     `-'   
   //         ");

            Console.WriteLine("Welcome to Aphrodite Algorithm's Blog Spot Love Stop");
            Console.WriteLine("      Home of the Goddess of Love and Coding");
            Console.WriteLine("\n~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~\n");

            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1) Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 6) Search by Tag");
            Console.WriteLine(" 9) Change Background Color");
            Console.WriteLine(" 0) Exit");


            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": return new JournalManager(this, CONNECTION_STRING);
                case "2": return new BlogManager(this, CONNECTION_STRING);
                case "3": return new AuthorManager(this, CONNECTION_STRING);
                case "4": return new PostManager(this, CONNECTION_STRING);
                case "5": return new TagManager(this, CONNECTION_STRING);
                case "6": return new SearchManager(this, CONNECTION_STRING);
                case "9": return new ColorChanger(this, CONNECTION_STRING);
                case "0":
                    //Console.WriteLine("Good bye");
                    Console.WriteLine();
                    Console.WriteLine(@"~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~

     _     _     888888b.                     888
    (c).-.(c)    888  '88b                    888
     / ._. \     888  .88P                    888
   __\( Y )/__   8888888K.  888  888  .d88b.  888 
  (_.-/'-'\-._)  888  'Y88b 888  888 d8P  Y8b 888
     || o ||     888    888 888  888 88888888 Y8P 
   _.' `-' '._   888   d88P Y88b 888 Y8b.      '
  (.-./`-'\.-.)  8888888P'   'Y88888  'Y8888  888 
   `-'     `-'                   888 
                            Y8b d88P              
                              'Y88P'
            ");
                    return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
