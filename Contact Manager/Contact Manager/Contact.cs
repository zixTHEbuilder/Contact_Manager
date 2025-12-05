using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Manager
{
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email )
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
