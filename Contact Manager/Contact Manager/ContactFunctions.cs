using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Contact_Manager
{
    class ContactFunctions
    {
        Input input = new Input();
        List<Contact> contacts = new List<Contact>();
        static string DirectoryPath = @"C:\Users\xylea\source\repos\Contact_Manager\Contacts";
        string path;

        public ContactFunctions()
        {
            path = Path.Combine(DirectoryPath, @"Contacts.csv");
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public void AddContact()
        {
            string name = input.ReadString("Enter Contact Name", intChecker: true);
            long phoneNumber = input.ReadLong("Enter Phone Number", NumLimit: true);
            string Email = input.ReadString("Enter Email (Press enter if no Email)", EmptyString : true);
            Email = string.IsNullOrEmpty(Email) ? "No Email found for this person" : Email;

            contacts.Add(new Contact(name, phoneNumber, Email));
        }

        public void SaveContacts()
        {
            List<string> lines = new List<string>();
            using (FileStream add = new FileStream(path, FileMode.Create))
            {
                foreach (var contact in contacts)
                {
                    lines.Add($"Name : {contact.Name},Phone Number : {contact.PhoneNumber},Email : {contact.Email}");
                }
                string fileContent = string.Join(Environment.NewLine, lines);
                byte[] save = Encoding.UTF8.GetBytes(fileContent);
                add.Write(save, 0, save.Length);
                Console.WriteLine("Contact Saved");
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Contacts :\n");
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contacts[i].Name} | {contacts[i].PhoneNumber}");
            }
            int ReqDelete = input.ReadInt("Select the contact you want to delete");

            if (ReqDelete >= 1 && ReqDelete <= contacts.Count)
            {
                Console.WriteLine($"{contacts[ReqDelete - 1].Name} was deleted.");
                contacts.Remove(contacts[ReqDelete - 1]);
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Invalid contact selection.");
            }
        }

        public void LoadContacts()
        {
            if (File.Exists(path))
            {
                contacts.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0].Replace("Name : ", "").Trim();
                        string phoneString = parts[1].Replace("Phone Number : ", "").Trim();
                        string email = parts[2].Replace("Email : ", "").Trim();

                        if (int.TryParse(phoneString, out int phoneNumber))
                        {
                            contacts.Add(new Contact(name, phoneNumber, email));
                        }
                    }
                }
            }
        }
    }
}
