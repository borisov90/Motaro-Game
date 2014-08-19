namespace Game
{
    using System;
    using System.Threading;
    using System.IO;

    class StartMenu
    {
        public static void Initialize()
        {
            if (Sound.isPlayingMusicMenu == true && Sound.isStartedMusicMenu == false)
            {
                Sound.PlayMenuMusic();
                Sound.isStartedMusicMenu = true;
            }
            Text();
                            
            bool commandCorrect = false;
            while (!commandCorrect)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    WindowsSettings.Initialize();

                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 6, " _____", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 5, "|____ |", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 4, "    / /", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 3, "    \\ \\", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 2, ".___/ /", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 1, "\\____/ ", ConsoleColor.Red);
                    Sound.PlayThree();
                    Thread.Sleep(1100);
                    Console.Clear();

                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 6, " _____", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 5, "/ __  \\", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 4, "`' / /'", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 3, "  / /", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 2, "./ /___", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 1, "\\_____/", ConsoleColor.Red);
                    Sound.PlayTwo();
                    Thread.Sleep(1000);
                    Console.Clear();

                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 6, " __ ", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 5, "/  |", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 4, "`| |", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 3, " | |", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 2, "_| |_", ConsoleColor.Red);
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 1, WindowsSettings.WIN_HEIGHT / 2 - 1, "\\___/", ConsoleColor.Red);
                    Sound.PlayOne();
                    Thread.Sleep(1080);

                    Sound.PlayGo();
                    Thread.Sleep(1000);

                    StartGame.stopWatch1.Restart();
                    StartGame.Initialize();
                    commandCorrect = true;
                }

                else if (pressedKey.Key == ConsoleKey.M)
                {     
                    Sound.StopMenuMusic();
                }

                else if (pressedKey.Key == ConsoleKey.S)
                {
                    Sound.PlayMenuMusic();
                }

                else if (pressedKey.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    HelpMenu.Initialize();
                    commandCorrect = true;
                }

                else if (pressedKey.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Scores.Initialize();
                    commandCorrect = true;
                }

                else if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Environment.Exit(0); // TO DO - STOP Showing "Press any key" message
                    commandCorrect = true;
                }
            }
        }

        private static void Text()
        {
            StreamReader readerLogo = new StreamReader(@"..\..\ExternalFiles\logo.txt");
            using (readerLogo)
            {
                Console.WriteLine(readerLogo.ReadToEnd());
            }

            StreamReader readerSrartMenu = new StreamReader(@"..\..\ExternalFiles\startmenu.txt");
            using (readerSrartMenu)
            {
                Console.WriteLine(readerSrartMenu.ReadToEnd());
            }
        }
    }
}
