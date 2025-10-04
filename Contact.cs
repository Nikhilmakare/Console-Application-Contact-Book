// Contact.cs

/// <summary>
/// Represents a single contact with a name, phone number, and email.
/// </summary>
public class Contact
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}";
    }
}