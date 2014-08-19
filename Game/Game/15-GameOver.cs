namespace Game
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Threading;
    using System.Collections.Generic;

    /* TO DO : 
     * ADD limit to chars in Console.ReadLine();
            byte[] inputBuffer = new byte[5];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
     
     */

    class GameOver
    {
        public static string secondsTime;
        private static Stopwatch stopWatch;

        public static void Initialize()
        {
            Stopwatch stopWatch = new Stopwatch();

            Sound.StopIngameMusic();
            Sound.PlayMenuMusic();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Scores.ShowHighScores(ConsoleColor.Yellow);

            DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 5, WindowsSettings.WIN_HEIGHT / 2 - 8, "Game Over!", ConsoleColor.Red);
            DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 10, WindowsSettings.WIN_HEIGHT / 2 - 5, "Your scores are " + Scores.currentScores, ConsoleColor.Red);
            DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 10, WindowsSettings.WIN_HEIGHT / 2 - 3, "Enter your name: ", ConsoleColor.Red);
            DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 25, WindowsSettings.WIN_HEIGHT / 2 + 5, "The name should be between 3 and 10 symbols!", ConsoleColor.White);

            // ENTER YOUR NAME starts //
            Console.CursorVisible = true;
            while (Scores.playerNameGameOver.Length < 3 || Scores.playerNameGameOver.Length > 10)
            {
                Console.SetCursorPosition(WindowsSettings.WIN_WIDTH / 2 + 7, WindowsSettings.WIN_HEIGHT / 2 - 3);
                Scores.playerNameGameOver = Console.ReadLine().ToUpper().TrimStart(' ').TrimEnd(' ');
            }    
            Console.CursorVisible = false;
            // ENTER YOUR NAME ends //
            
            Scores.WriteScores();
            Console.Clear();

            stopWatch.Start();
            TimeSpan timeSpan = new TimeSpan();

            while (true)
            {
                TimeSpan diagnoze = DateTime.Now.AddSeconds(11) - DateTime.Now;
                timeSpan = diagnoze.Subtract(stopWatch.Elapsed);
                secondsTime = String.Format("{0}", timeSpan.Seconds.ToString("00"));

                Scores.ShowHighScores(ConsoleColor.Yellow);

                DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH / 2 - 10, 24, "Time elapsed to restart the game: " + secondsTime, ConsoleColor.White);
                DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH / 2 - 10, 26, "To EXIT the game press ESC button", ConsoleColor.White);

                /////////// checks if the player is in top 5 ///////////
                List<string> topFive = Scores.GetHighScores();

                bool inTopFive = false;

                for (int index = 0; index < topFive.Count; index++)
                {
                    string[] scoreAndName = topFive[index].Split(new char[] { '|' }); // split the line, gets the name and points

                    if (scoreAndName[1] == Scores.playerNameGameOver
                        && scoreAndName[0].TrimStart('0') == Convert.ToString(Scores.currentScores))
                    {
                        DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 10, WindowsSettings.WIN_HEIGHT / 2 - 8, "YOU ARE IN TOP 5");
                        inTopFive = true;
                        break;
                    }
                }

                if (inTopFive == false)
                {
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 12, WindowsSettings.WIN_HEIGHT / 2 - 8, "You are NOT in TOP 5");
                    DrawItem.Draw(WindowsSettings.WIN_WIDTH / 2 - 8, WindowsSettings.WIN_HEIGHT / 2 - 6, "Try again!");
                }

                /////////// checks if the player is in top 5 ///////////



                // RESETS THE GAME TO START AGAIN A NEW ONE
                bool commandCorrect = false;
                if (secondsTime == "00")
                {
                    stopWatch.Stop();                   
                    Console.Clear();

                    Player.playerLife = 200;
                    Player.playerPositionX = WindowsSettings.GAME_AREA_WIDTH / 2 - 3;
                    Player.playerPositionY = WindowsSettings.GAME_AREA_HEIGHT - Player.PLAYER_HEIGHT - 4;
                    Bombs.bombsList = new List<int[]>();
                    Bombs.bombNumber = 0;
                    Bandit.banditPositionX = WindowsSettings.GAME_AREA_WIDTH;
                    Bandit.banditPositionY = Bandit.randomGenerator.Next(5, 25);
                    Rackets.shots = new List<List<int>>();
                    Scores.currentScores = 0;
                    Scores.playerNameGameOver = "";

                    WindowsSettings.Initialize();
                    StartMenu.Initialize();
                    break;              
                }

                // ESCAPE AND EXIT
                else if (Console.KeyAvailable)
                {                    
                    while (!commandCorrect)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Environment.Exit(0); // TODO: - STOP Showing "Press any key" message
                            commandCorrect = true;
                            break;
                        }
                    }
                }
            } 
        }
    }
}