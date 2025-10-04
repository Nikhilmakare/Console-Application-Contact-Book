// ContactManager.cs
using System.Text.Json;

/// <summary>
/// Manages all operations related to the contact list,
/// including loading from and saving to a file.
/// </summary>
public class ContactManager
{
    private List<Contact> _contacts;
    private const string FilePath = "contacts.json";

    public ContactManager()
    {
        _contacts = new List<Contact>();
        LoadContacts();
    }

    public void AddContact()
    {
        Console.WriteLine("\n--- Add New Contact ---");
        Console.Write("Enter Name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string? phone = Console.ReadLine();

        Console.Write("Enter Email: ");
        string? email = Console.ReadLine();

        _contacts.Add(new Contact { Name = name, PhoneNumber = phone, Email = email });
        Console.WriteLine("Contact added successfully!");
    }

    public void ViewAllContacts()
    {
        Console.WriteLine("\n--- All Contacts ---");
        if (_contacts.Count == 0)
        {
            Console.WriteLine("Your contact book is empty.");
            return;
        }

        foreach (var contact in _contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void SearchContact()
    {
        Console.WriteLine("\n--- Search Contacts ---");
        Console.Write("Enter a name to search for: ");
        string? searchTerm = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            Console.WriteLine("Search term cannot be empty.");
            return;
        }

        var results = _contacts.Where(c => c.Name != null && c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No contacts found with that name.");
        }
        else
        {
            Console.WriteLine("Found contacts:");
            foreach (var contact in results)
            {
                Console.WriteLine(contact);
            }
        }
    }

    private void LoadContacts()
    {
        if (!File.Exists(FilePath))
        {
            return; // No file to load, start with an empty list
        }

        try
        {
            string json = File.ReadAllText(FilePath);
            var loadedContacts = JsonSerializer.Deserialize<List<Contact>>(json);
            if (loadedContacts != null)
            {
                _contacts = loadedContacts;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading contacts: {ex.Message}");
        }
    }

    public void SaveChanges()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_contacts, options);
        File.WriteAllText(FilePath, json);
        Console.WriteLine("Changes saved successfully.");
    }
}