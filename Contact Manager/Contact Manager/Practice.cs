using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Manager
{
    class Practice
    {
        public void practiceArea()
        {
            string DirectoryPath = @"C:\Users\xylea\source\repos\Contact_Manager\Contacts";
            string ContactPath = Path.Combine(DirectoryPath, @"test.txt");

            Directory.CreateDirectory(DirectoryPath);


            using (FileStream contactTest = new FileStream(ContactPath, FileMode.Create))
            {
                byte[] data = Encoding.UTF8.GetBytes("Stream Based File Writing");      // this converts to Bytes so the data gets stored in bytes
                contactTest.Write(data, 0, data.Length);    //what you want to write , at what index you want to start writing, how many indexes you want to fill 
                Console.WriteLine("Stream Completed");
            }

            byte[] data1 = { 1, 2, 3, 4, 5, 6 };
            File.WriteAllBytes(Path.Combine(DirectoryPath, @"test.bin"), data1);     // normally if you dont decode the text is  not gonna be readable, this proves it

            using (FileStream ContactReadTest = new FileStream(ContactPath, FileMode.Open))
            {
                byte[] dataread = new byte[ContactReadTest.Length];
                ContactReadTest.Read(dataread, 0, dataread.Length);
                string content = Encoding.UTF8.GetString(dataread);    //in this case we write Encoding.UTF8 after reading because it doesn't know what to convert, so we open and then convert
                Console.WriteLine($"Content : {content}");

            }
        }
    }
}
