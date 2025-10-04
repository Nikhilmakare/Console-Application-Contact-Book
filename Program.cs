// Program.cs

class Program
{
    static void Main(string[] args)
    {
        ContactManager contactManager = new ContactManager();
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("--- Console Contact Book ---");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Search for Contact");
            Console.WriteLine("4. Exit");
            Console.Write("\nPlease select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    contactManager.AddContact();
                    break;
                case "2":
                    contactManager.ViewAllContacts();
                    break;
                case "3":
                    contactManager.SearchContact();
                    break;
                case "4":
                    contactManager.SaveChanges();
                    isRunning = false;
                    Console.WriteLine("Exiting application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}