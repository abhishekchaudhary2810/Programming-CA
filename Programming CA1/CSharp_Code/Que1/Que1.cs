using System;
using System.Collections.Generic;

public class Contact
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string Birthdate { get; set; }

    public Contact() { }

    public Contact(string firstName, string lastName, string mobileNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        MobileNumber = mobileNumber;
    }
}
public class ContactBook
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact()
    {
        Contact c = new Contact();

        Console.Write("Enter First Name: ");
        c.FirstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        c.LastName = Console.ReadLine();

        Console.Write("Enter Company: ");
        c.Company = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter Mobile Number (9 digits): ");
            string mobile = Console.ReadLine();

            if (mobile.Length == 9 &&
                long.TryParse(mobile, out _) &&
                mobile != "000000000")
            {
                c.MobileNumber = mobile;
                break;
            }

            Console.WriteLine("Invalid mobile number! Try again.");
        }

        Console.Write("Enter Email: ");
        c.Email = Console.ReadLine();

        Console.Write("Enter Birthdate: ");
        c.Birthdate = Console.ReadLine();

        contacts.Add(c);
        Console.WriteLine("Contact added successfully!");
    }

    public void ShowAllContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
            return;
        }

        Console.WriteLine("\n--- All Contacts ---");
        foreach (var c in contacts)
        {
            Console.WriteLine($"{c.FirstName} {c.LastName} - {c.MobileNumber}");
        }
    }

    public void ShowContactDetails()
    {
        Console.Write("Enter mobile number to search: ");
        string mobile = Console.ReadLine();

        Contact c = contacts.Find(x => x.MobileNumber == mobile);

        if (c == null)
        {
            Console.WriteLine("Contact not found!");
            return;
        }

        Console.WriteLine("\n--- Contact Details ---");
        Console.WriteLine($"First Name: {c.FirstName}");
        Console.WriteLine($"Last Name: {c.LastName}");
        Console.WriteLine($"Company: {c.Company}");
        Console.WriteLine($"Mobile: {c.MobileNumber}");
        Console.WriteLine($"Email: {c.Email}");
        Console.WriteLine($"Birthdate: {c.Birthdate}");
    }

    public void UpdateContact()
    {
        Console.Write("Enter mobile number of contact to update: ");
        string mobile = Console.ReadLine();

        Contact c = contacts.Find(x => x.MobileNumber == mobile);

        if (c == null)
        {
            Console.WriteLine("Contact not found!");
            return;
        }

        Console.Write("Enter new First Name: ");
        c.FirstName = Console.ReadLine();

        Console.Write("Enter new Last Name: ");
        c.LastName = Console.ReadLine();

        Console.Write("Enter new Company: ");
        c.Company = Console.ReadLine();

        Console.Write("Enter new Email: ");
        c.Email = Console.ReadLine();

        Console.Write("Enter new Birthdate: ");
        c.Birthdate = Console.ReadLine();

        Console.WriteLine("Contact updated successfully!");
    }
    public void DeleteContact()
    {
        Console.Write("Enter mobile number of contact to delete: ");
        string mobile = Console.ReadLine();

        Contact c = contacts.Find(x => x.MobileNumber == mobile);

        if (c == null)
        {
            Console.WriteLine("Contact not found!");
            return;
        }

        contacts.Remove(c);
        Console.WriteLine("Contact deleted successfully!");
    }
}

class Program
{
    static void Main()
    {
        ContactBook contactBook = new ContactBook();
        int choice;

        do
        {
            Console.WriteLine("\n---- MAIN MENU ----");
            Console.WriteLine("1: Add Contact");
            Console.WriteLine("2: Show All Contacts");
            Console.WriteLine("3: Show Contact Details");
            Console.WriteLine("4: Update Contact");
            Console.WriteLine("5: Delete Contact");
            Console.WriteLine("0: Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Try again.");
                continue;
            }

            switch (choice)
            {
                case 1: contactBook.AddContact(); break;
                case 2: contactBook.ShowAllContacts(); break;
                case 3: contactBook.ShowContactDetails(); break;
                case 4: contactBook.UpdateContact(); break;
                case 5: contactBook.DeleteContact(); break;
                case 0: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice!"); break;
            }

        } while (choice != 0);
    }
}
