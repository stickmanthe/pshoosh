using Cosmos.System.ExtendedASCII;
using pshoosh.ShooshG;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace progressor
{
    public class Kernel : Sys.Kernel
    {
        private List<string> commandHistory;
        private int commandIndex;
        private StringBuilder currentCommand;
        private int cursorPosition;
        public static string BSODError;
        public static string Dirc = @"0:\";
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();


        protected override void BeforeRun()
        {
            try
            {
                Console.OutputEncoding = CosmosEncodingProvider.Instance.GetEncoding(437);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("  Welcome to Progressor Shoosh 0.1.01 Github version of May 2024  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

                commandHistory = new List<string>();
                commandIndex = 0;
                currentCommand = new StringBuilder();
                cursorPosition = 0;
            }
            catch (Exception e)
            {
                SystemCrash(e.ToString());
            }
        }

        protected override void Run()
        {
            try
            {
                Console.Write($"{Dirc}>");
                var command = Console.ReadLine();
                ExecuteCommand(command);
            }
            catch (Exception e)
            {
                SystemCrash(e.ToString());
            }
        }

        public static void SystemCrash(string e)
        {
            if (Shooshg.Visib == true)
            {
                BSODError = e;
                BSOD.Run();
            }
            else
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.Beep(500, 500);
                Console.WriteLine("A problem has been detected on this computer and system has had to shut down.");
                Console.WriteLine("CRITICAL ERROR: " + e);
                Console.WriteLine("");
                Console.WriteLine("Press any key to restart computer...");
                Console.ReadKey(true);
                Sys.Power.Reboot();
            }
        }
        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "help":
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("help - Display available commands; read [file name] - Display text from file;");
                    Console.WriteLine("shooshg - Starts Graphical Interface; mkdir [folder name] - Create folder;");
                    Console.WriteLine("fetch - Show the PC info; create [file name] - Create file;");
                    Console.WriteLine("dir - Read all file names in directory; cd [directory] - Go into directory;");
                    Console.WriteLine("delete [file name] - Delete file or directory;");
                    Console.WriteLine("time - Show the current time;");
                    Console.WriteLine("date - Show the current date;");
                    Console.WriteLine("echo [message] - Display the given message;");
                    Console.WriteLine("cls - Clear the screen;");
                    Console.WriteLine("reboot - Reboots OS;");
                    Console.WriteLine("shutdown - Shutdowns OS.");
                    Console.WriteLine();
                    break;

                case "time":
                    var currentTime = DateTime.Now.ToString("HH:mm:ss");
                    Console.WriteLine($"Current time: {currentTime}");
                    break;

                case "fetch":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{Cosmos.Core.CPU.GetCPUBrandString()}");
                    Console.WriteLine($"RAM: {Cosmos.Core.CPU.GetAmountOfRAM()} MB");
                    Console.WriteLine("Kernel: PShoosh");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case "date":
                    var currentDate = DateTime.Now.ToString("dd.MM.yyyy");
                    Console.WriteLine($"Current date: {currentDate}");
                    break;

                case "shooshg":
                    if (Shooshg.Visib == true)
                    {
                        Console.WriteLine("Shoosh Graphical Interface is running right now!");
                    }
                    else
                    {
                        if (Cosmos.Core.CPU.GetAmountOfRAM() >= 250)
                        {
                            Console.WriteLine($"Booting Shoosh Graphical Interface...");
                            Shooshg.BeforeRun();
                            if (Shooshg.Visib == true)
                            {
                                for (; ; )
                                Shooshg.Run();
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough RAM to run the GUI. 512 MB is recommended for it. Sorry!");
                        }
                    }
                    break;

                case string cmd when cmd.StartsWith("echo "):
                    var message = cmd.Substring(5);
                    Console.WriteLine(message);
                    break;

                case "dir":
                    try
                    {
                        string[] arrayDirectory = Directory.GetDirectories(Dirc);
                        string[] arrayFile = Directory.GetFiles(Dirc);

                        for (int i = 0; i < arrayDirectory.Length; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.White; Console.Write($"Directory - "); Console.ForegroundColor = ConsoleColor.Gray; Console.Write($"{arrayDirectory[i]}\n");
                        }

                        for (int i = 0; i < arrayFile.Length; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.White; Console.Write($"File - Size: {arrayFile[i].Length} B - "); Console.ForegroundColor = ConsoleColor.Gray; Console.Write($"{arrayFile[i]}\n");
                        }
                        Console.WriteLine($"Free Disk Space is {fs.GetAvailableFreeSpace(@"0:\") / 1e+6} MB and Used {fs.GetTotalSize(@"0:\") - fs.GetAvailableFreeSpace(@"0:\")} B");
                    }
                    catch
                    {
                        Console.WriteLine("Read Failed.");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case string cmd when cmd.StartsWith("read "):
                    try
                    {
                        var filename = cmd.Substring(5);
                        Console.WriteLine(File.ReadAllText($"{Dirc}{filename}"));
                    }
                    catch
                    {
                        Console.WriteLine("Unknown File!");
                    }
                    break;

                case string cmd when cmd.StartsWith("delete "):
                    try
                    {
                        var filedelete = cmd.Substring(7);
                        if (filedelete.StartsWith("\\"))
                        {
                            Directory.Delete($"{Dirc}{filedelete.Substring(1)}");
                        }
                        else
                        {
                            File.Delete($"{Dirc}{filedelete}");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Unknown File/Directory!");
                    }
                    break;

                case string cmd when cmd.StartsWith("create "):
                    var createfile = cmd.Substring(7);
                    File.Create($"{Dirc}{createfile}");
                    break;

                case string cmd when cmd.StartsWith("cd "):
                    var getin = cmd.Substring(3);
                    if (getin.StartsWith(Dirc))
                    {
                        Dirc = $"{getin}\\";
                    }
                    else if (getin.StartsWith("\\"))
                    {
                        Dirc = $"{Dirc}{getin.Substring(1)}\\";
                    }
                    else if (getin == "-")
                    {
                        if (Dirc.LastIndexOf('\\') >= 4)
                        {
                            Dirc = Dirc.Substring(0, Dirc.LastIndexOf('\\'));
                        }
                        else
                        {
                            Console.WriteLine("Nothing to do!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unknown Directory...");
                    }
                    break;

                case "cls":
                    Console.Clear();
                    break;

                case string cmd when cmd.StartsWith("mkdir "):
                    var mkdirr = cmd.Substring(6);
                    break;

                case "shutdown":
                    Sys.Power.Shutdown();
                    break;

                case "reboot":
                    Sys.Power.Reboot();
                    break;

                default:
                    Console.WriteLine("Invalid command. Type 'help' for a list of available commands.");
                    break;
            }
        }

        /*
        private string ReadCommand()
        {
            cursorPosition = 0;
            currentCommand.Clear();

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (cursorPosition > 0)
                        {
                            cursorPosition--;
                            currentCommand.Remove(cursorPosition, 1);
                            UpdateCommandText();
                            UpdateCursorPosition();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (cursorPosition > 0)
                        {
                            cursorPosition--;
                            UpdateCursorPosition();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (cursorPosition < currentCommand.Length)
                        {
                            cursorPosition++;
                            UpdateCursorPosition();
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        cursorPosition = 0;
                        NavigateCommandHistory(-1);
                        break;

                    case ConsoleKey.DownArrow:
                        cursorPosition = 0;
                        NavigateCommandHistory(1);
                        break;

                    default:
                        if (!char.IsControl(key.KeyChar))
                        {
                            currentCommand.Insert(cursorPosition, key.KeyChar);
                            cursorPosition++;
                            UpdateCommandText();
                            UpdateCursorPosition();
                        }
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            var command = currentCommand.ToString();
            return command;
        }

        private void UpdateCommandText()
        {
            var cursorTop = Console.CursorTop;
            var windowWidth = Console.WindowWidth;
            Console.Write(new string(' ', windowWidth));
            if (currentCommand.Length > windowWidth - 1)
            {
                currentCommand.Remove(windowWidth, currentCommand.Length - windowWidth);
            }

            Console.SetCursorPosition(1, cursorTop);
            Console.Write(Dirc.Substring(1) + ">" + currentCommand.ToString());
            Console.SetCursorPosition(Dirc.Length + cursorPosition, cursorTop);
        }

        private void UpdateCursorPosition()
        {
            Console.SetCursorPosition(Dirc.Length + cursorPosition + 1, Console.CursorTop);
        }

        private void NavigateCommandHistory(int offset)
        {
            var newIndex = commandIndex + offset;

            if (newIndex >= 0 && newIndex < commandHistory.Count)
            {
                commandIndex = newIndex;
                currentCommand.Clear();
                currentCommand.Append(commandHistory[commandIndex]);
                cursorPosition = currentCommand.Length;
                UpdateCommandText();
                UpdateCursorPosition();
            }
            else if (newIndex == commandHistory.Count)
            {
                commandIndex = newIndex;
                currentCommand.Clear();
                UpdateCommandText();
                UpdateCursorPosition();
            }
        }
        */
    }
}
