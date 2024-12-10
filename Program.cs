using System.ComponentModel.Design;

namespace SharpFetch
{
    internal class Program
    {
        static void Text(string text, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ASCII_DRAW_DISTRO(string distro)
        {
            string[,] ArchArt = new string[7, 1]
            {
                {"        /\\"},
                {"       /  \\"},
                {"      /\\   \\"},
                {"     / > ω <\\"},
                {"    /   __   \\"},
                {"   / __|  |__-\\"},
                {"  /_-''    ''-_\\"},
            };

            string[,] FedoraArt = new string[9, 1]
            {
                {"        ,'''''."},
                {"       |   ,.  |"},
                {"       |  |  '_'"},
                {"  ,....|  |.."},
                {".'  ,_;|   ..'"},
                {"|  |   |  |"},
                {"|  ',_,'  |"},
                {"'.       ,'"},
                {"  '''''''"}
            };

            string[,] MintArt = new string[7, 1]
            {
                {" ______________"},
                {"|_             \\"},
                {"  | |__________|"},
                {"  | |  |  |  | |"},
                {"  | |  |  |  | |"},
                {"  | \\__________|"},
                {"  \\___________/"}
            };

            switch (distro)
            {
                case "arch":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    for (int i = 0; i < ArchArt.GetLength(0); i++)
                    {
                        for (int j = 0; j < ArchArt.GetLength(1); j++)
                        {
                            Console.WriteLine(ArchArt[i, j]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "fedora":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    for (int i = 0; i < FedoraArt.GetLength(0); i++)
                    {
                        for (int j = 0; j < FedoraArt.GetLength(1); j++)
                        {
                            Console.WriteLine(FedoraArt[i, j]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "mint":
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < MintArt.GetLength(0); i++)
                    {
                        for (int j = 0; j < MintArt.GetLength(1); j++)
                        {
                            Console.WriteLine(MintArt[i, j]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void DistroInformation(bool OnClose, string ChosenDistro)
        {
            Dictionary<string, string> ArchSysReq = new Dictionary<string, string>()
            {
                {"Minimum Free Space", "800mb"},
                {"Minimum RAM", "512mb" },
                {"Rating on Distrowatch", "9.23/10 from 229 reviews" }
            };

            Dictionary<string, string> FedoraSysReq = new Dictionary<string, string>() 
            {
                {"Minimum Free Space", "15gb"},
                {"Minimum RAM", "2gb"},
                {"Rating on Distrowatch", "8.27/10 from 353 reviews"}
            };

            Dictionary<string, string> MintSysReq = new Dictionary<string, string>()
            {
                {"Minimum Free Space", "2gb"},
                {"Minimum RAM", "20gb"},
                {"Rating on Distrowatch", "8.75/10 from 737 reviews"}
            };
            string InfoDesire;
            Text("Would you like to know system requirements for this distro ? y/n ", ConsoleColor.Magenta);
            InfoDesire = Console.ReadLine();
            if (InfoDesire.ToLower() == "y" && ChosenDistro == "arch")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (var pair in ArchSysReq)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if(InfoDesire.ToLower() == "y" && ChosenDistro == "fedora")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (var pair in FedoraSysReq)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if(InfoDesire.ToLower() == "y" && ChosenDistro == "mint")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (var pair in MintSysReq)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (InfoDesire.ToLower() == "n")
            {
                OnClose = true;
                Console.ForegroundColor= ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("There's no such command as " + "'" + InfoDesire + "'");
            }
        }


        
        static void Main(string[] args)
        {
            List<string> DistrosList = new List<string>()
            {
                "Arch", "Mint", "Fedora"
            };


            bool ClosedOrNot = false;
            Text("'Help' or 'Exit' available", ConsoleColor.DarkGray);
            while (ClosedOrNot == false)
            {
                string UsersChoice;
                Console.Write("Choose distro: ");
                UsersChoice = Console.ReadLine();

                switch (UsersChoice.ToLower())
                {
                    case "arch":
                        ASCII_DRAW_DISTRO(UsersChoice.ToLower());
                        DistroInformation(ClosedOrNot, UsersChoice.ToLower());
                        continue;
                    case "fedora":
                        ASCII_DRAW_DISTRO(UsersChoice.ToLower());
                        DistroInformation(ClosedOrNot, UsersChoice.ToLower());
                        continue;
                    case "mint":
                        ASCII_DRAW_DISTRO(UsersChoice.ToLower());
                        DistroInformation(ClosedOrNot, UsersChoice.ToLower());
                        continue;
                    case "exit":
                        ClosedOrNot = true;
                        break;
                    case "help":
                        Text("help's for dummies (use 'list' command to see list of available distros)", ConsoleColor.Green);
                        break;
                    case "list":
                        foreach (string Distros in DistrosList)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"{Distros}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        continue;
                }

            }
        }
    }
}
