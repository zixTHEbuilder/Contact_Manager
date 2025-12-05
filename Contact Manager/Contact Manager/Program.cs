using Contact_Manager;
using System.Text;

namespace ContactManager
{
    class Program
    {

        static void Main()
        {
            while (true)
            {
                Input input = new Input();
                ContactFunctions contact = new ContactFunctions();
                int Program = input.ReadInt("Choose an option :\n1.Add a Contact \n2.View Contacts \n3.Delete Contacts", writeLine: true);
                switch (Program)
                {
                    case 1:
                        {
                            contact.AddContact(); break;
                        }
                    case 2:
                        {
                            contact.LoadContacts(); break;
                        }
                    case 3:
                        {
                            contact.DeleteContact(); break;
                        }
                    case 4:
                        {
                            return;
                        }
                    default: { Console.WriteLine("Invalid Input, Please Select a Program!"); break; }
                }
            }
        }

    }
}