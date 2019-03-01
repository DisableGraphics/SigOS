using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace SigOS
{
    public class Kernel : Sys.Kernel
    {
        
        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Console.WriteLine("SigOS booted successfully.");

        }

        protected override void Run()
        {
            Console.WriteLine("");
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);

            if(input == "read")
            {
                Console.WriteLine("Input the address of the file");

                string FileAddress = Console.ReadLine();
                string content;


                if (File.Exists(FileAddress))
                {
                    string f_contents = "";
                    f_contents = File.ReadAllText(FileAddress);
                    content = f_contents;

                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("File not found");

                }
            }

            if (input == "hello")
            {

                Console.Write("Hello user. Thanks for using SigOS :D");

            }

            if (input == "shutdown")
            {
                Console.Beep();

                Sys.Power.Shutdown();

            }

            if (input == "reboot")
            {
                Console.Beep();

                Sys.Power.Reboot();

            }

            if (input == "about")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("SigOS (Security Intended Great Operative System) Copyright DisableGraphics Jan 2019");
                Console.WriteLine("SigOS version 1.1 Codename 'Brad'");

                Console.ForegroundColor = ConsoleColor.White;

            }

            if (input == "help")
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("help - display help");
                Console.WriteLine("about - shows the information of the OS");
                Console.WriteLine("hello - get hello-ed!");
                Console.WriteLine("beep - make the computer beep");

                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("edit - edit text files easily");
                Console.WriteLine("notepad - a (very) basic notepad");
                Console.WriteLine("read - read a text file");
                Console.WriteLine("del - delete a file");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("shutdown - shutdown the system");
                Console.WriteLine("reboot - reboot the computer");

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("game - yust another random number game");

                Console.ForegroundColor = ConsoleColor.White;
            }

            if (input == "edit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Input the address of the file");

                Console.ForegroundColor = ConsoleColor.White;

                string FileAddress = Console.ReadLine();
                string contents = File.ReadAllText(FileAddress);

                if (File.Exists(FileAddress))
                {
                    Console.Write(contents);

                    string editision = Console.ReadLine();

                    if (Console.ReadKey().Key == ConsoleKey.F2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.WriteLine("Do you want to save it to a new file? [Y/N]");

                        Console.ForegroundColor = ConsoleColor.White;

                        string inpt = Console.ReadLine();

                        if (inpt == "Y") {

                            string finalEdit = contents + " " + editision;

                            File.WriteAllText(FileAddress,finalEdit);

                            Console.WriteLine("File saved succesfully");

                        }
                        if (inpt == "y")
                        {

                            string finalEdit = contents + " " + editision;

                            File.WriteAllText(FileAddress, finalEdit);

                            Console.WriteLine("File saved succesfully");
                        }
                        if (inpt == "N")
                        {
                            string finalEdit = contents + " " + editision;

                            Console.ForegroundColor = ConsoleColor.Cyan;

                            Console.WriteLine("Do you want to save it?[Y/N]");

                            Console.ForegroundColor = ConsoleColor.White;

                            string yesno = Console.ReadLine();

                            if(yesno == "Y")
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                Console.WriteLine("Input the name of the file");

                                Console.ForegroundColor = ConsoleColor.White;

                                string name = Console.ReadLine();

                                File.WriteAllText(name,finalEdit);

                                Console.WriteLine("File saved succesfully");

                            }

                        }
                        if (inpt == "n")
                        {
                            string finalEdit = contents + " " + editision;

                            Console.ForegroundColor = ConsoleColor.Cyan;

                            Console.WriteLine("Do you want to save it?[Y/N]");

                            Console.ForegroundColor = ConsoleColor.White;

                            string yesno = Console.ReadLine();

                            if (yesno == "y")
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                Console.WriteLine("Input the name of the file");

                                Console.ForegroundColor = ConsoleColor.White;

                                string name = Console.ReadLine();

                                File.WriteAllText(name, finalEdit);

                                Console.WriteLine("File saved succesfully"); 

                            }

                        }

                    }

                }

            }

            if (input == "notepad")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Type text to save it to a file");

                Console.ForegroundColor = ConsoleColor.Gray;

                string text = Console.ReadLine();

                if (Console.ReadKey().Key == ConsoleKey.F2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("Do you want to save the file? [Y/N]");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    var sav = Console.ReadLine();

                    if (sav == "Y") {

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("Please enter the name of the file you want to save");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    string name = Console.ReadLine();

                    Console.WriteLine("Saving file as " + name);

                    System.IO.File.Create(@"0:\" + name);

                    File.WriteAllText(name, text);
                    }

                    if (sav == "y")
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.WriteLine("Please enter the name of the file you want to save");

                        Console.ForegroundColor = ConsoleColor.Gray;

                        string name = Console.ReadLine();

                        Console.WriteLine("Saving file as " + name);

                        System.IO.File.Create(@"0:\" + name);

                        File.WriteAllText(name, text);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "del")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Write the name of the file you want to delete");

                Console.ForegroundColor = ConsoleColor.Gray;

                string deleteFile = Console.ReadLine();

                if (File.Exists(deleteFile))
                {
                    File.Delete(deleteFile);

                    Console.WriteLine("File has been succesfully deleted");

                    Console.ForegroundColor = ConsoleColor.White;
                }

                else
                {
                    Console.WriteLine("You cannot delete this inexistent file");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
            
            if(input == "beep")
            {
                Console.Beep();

            }
            if(input == "game")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Type a random number from 1 to 5");

                Console.ForegroundColor = ConsoleColor.Gray;

                string gotNumber = Console.ReadLine();

                if (gotNumber != "114329")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("Sorry, you got it wrong");
                    Console.WriteLine("Try again");

                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("You got the secret of this operative system");

                    Console.Write("The OS must be ");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("uninstalled");

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("");
                    Console.WriteLine("'You knew it' DisableGraphics 20whateveryearisnow");
                    Console.WriteLine("bye bye said Sig");

                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "random")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("Welcome to the random module of SigOS");
                Console.WriteLine("Well, first we're going to go deep in history");
                Console.WriteLine("December, 2018. Me, Dg, I'm developing the first version of this OS");
                Console.WriteLine("The week before the release I found the code very messy");
                Console.WriteLine("What is this? Will you thinking. Why are you telling me this?");
                Console.WriteLine("Fellow user of SigOS, sincerely I don't know why am I telling you this");
                Console.WriteLine("I think it's the magic of the random module, Isn't it?");
                Console.WriteLine("Meh, I am bored, why I don't troll this user a bit?");
                Console.WriteLine("Nah, Too waste of code");
                Console.WriteLine("*Sigh* I am talking to myself *Sigh* #ForeverAlone");

                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "linux")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Linux? Send it to HELL!! This isn't Linux");
                Console.WriteLine("Linux SUCKS, OK? This is SigOS, Who needs Linux?");

                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "internet")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Sorry, the internet is busy, please wait to the release of the internet in SigOS");

                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}
