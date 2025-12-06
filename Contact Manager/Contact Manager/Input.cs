using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace Contact_Manager
{
    class Input
    {
        public string ReadString(string message, bool intChecker = false, bool writeLine = false, bool EmptyString = false)
        {
            while (true)
            {
                if (writeLine)
                    Console.WriteLine($"{message} : ");
                else
                    Console.Write($"{message} : ");

                try
                {
                    string UserInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(UserInput))
                    {
                        if (intChecker)
                        {
                            bool intCheck = UserInput.All(c => char.IsLetter(c) || c == ' ');
                            if (intCheck)
                                return UserInput;
                            else
                            {
                                Console.WriteLine("Name cannot contain any numbers or symbols!");
                                continue;
                            }
                        }
                        else
                            return UserInput;
                    }

                    if (EmptyString)
                        return null;

                    Console.WriteLine("Name cannot be empty");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
            }
        }

        public long ReadLong(string message, bool writeLine = false, bool NumLimit = false)
        {
            while (true)
            {
                if (writeLine)
                    Console.WriteLine($"{message} : ");
                else
                    Console.Write($"{message} : ");

                string UserInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(UserInput))
                {
                    bool success = long.TryParse(UserInput, out long result);
                    if (success)
                    {
                        if (NumLimit)
                        {
                            if (UserInput.Length != 10)
                            {
                                Console.WriteLine("Enter a 10 Digit Phone Number");
                                continue;
                            }
                            return result;
                        }
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Number");
                        continue;
                    }
                }
                Console.WriteLine("Input cannot be empty");
            }
        }

        public int ReadInt(string message, bool writeLine = false, bool NumLimit = false)
        {
            while (true)
            {
                if (writeLine)
                    Console.WriteLine($"{message} : ");
                else
                    Console.Write($"{message} : ");

                string UserInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(UserInput))
                {
                    bool success = int.TryParse(UserInput, out int result);
                    if (success)
                    {
                        if (NumLimit)
                        {
                            if (UserInput.Length != 10)
                            {
                                Console.WriteLine("Enter a 10 Digit Phone Number");
                                continue;
                            }
                            return result;
                        }
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Number");
                        continue;
                    }
                }
                Console.WriteLine("Input cannot be empty");
            }
        }
    }
}