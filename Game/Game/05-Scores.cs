namespace Game
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Scores
    {
        private const string FILEPATH = @"..\..\ExternalFiles\scoreboard.txt";

        public static int currentScores = 0;
        public static string playerNameGameOver = "";

        // STARTS THE HIGH SCORES BOARD
        public static void Initialize()
        {
            List<string> allScores = GetAllScores();

            string[] currentScoreAndName;

            DrawItem.Draw(10, 0, "\n" + "                         HIGH SCORES:" + "\n");
            DrawItem.Draw(10, 3, "*========================================*");

            int linesNumber = (allScores.Count > 30) ? 30 : allScores.Count;

            for (int index = 0; index < allScores.Count; index++)
            {
                currentScoreAndName = allScores[index].Split(new char[] { '|' });

                string scores = "";

                if (currentScoreAndName[0] != "0000")
                {
                    scores = currentScoreAndName[0].TrimStart('0');
                }
                else
                {
                    scores = "0";
                }

                string lineString = String.Format("* Player {0}: {1}", currentScoreAndName[1], scores);
                DrawItem.Draw(10, 4 + index, lineString);
                DrawItem.Draw(51, 4 + index, "*");
            }

            if (allScores.Count < 5)
            {
                int emptyRows = 5 - allScores.Count;
                while (emptyRows != 0)
                {
                    DrawItem.Draw(10, 4 + (5 - emptyRows), "*");
                    DrawItem.Draw(51, 4 + (5 - emptyRows), "*");
                    emptyRows--;
                }
            }

            Console.WriteLine("\n" + "          *========================================*");

            DrawItem.Draw(25, WindowsSettings.WIN_HEIGHT - 4, "Click ESC to return");

            bool commandCorrect = false;

            while (!commandCorrect)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    StartMenu.Initialize();
                    commandCorrect = true;
                }
            }
        }

        // READS THE STATISTICS of the HIGH Scores
        public static void ShowHighScores(ConsoleColor textcolor = ConsoleColor.White)
        {
            try
            {
                List<string> fiveTopPlayers = GetHighScores();

                string[] currentScoreAndName;

                // PRINTS TOP 5 PLAYERS w. HIGH SCORES

                DrawItem.Draw(10, 0, "\n" + "                         HIGH SCORES:" + "\n", textcolor);
                DrawItem.Draw(10, 3, "*========================================*", textcolor);

                for (int index = 0; index < fiveTopPlayers.Count; index++)
                {
                    currentScoreAndName = fiveTopPlayers[index].Split(new char[] { '|' });

                    string scores = "";

                    if (currentScoreAndName[0] != "0000")
                    {
                        scores = currentScoreAndName[0].TrimStart('0');
                    }
                    else
                    {
                        scores = "0";
                    }

                    string lineString = String.Format("* Player {0}: {1}", currentScoreAndName[1], scores);
                    DrawItem.Draw(10, 4 + index, lineString, textcolor);
                    DrawItem.Draw(51, 4 + index, "*", textcolor);
                }

                if (fiveTopPlayers.Count < 5)
                {
                    int emptyRows = 5 - fiveTopPlayers.Count;
                    while (emptyRows != 0)
                    {
                        DrawItem.Draw(10, 4 + (5 - emptyRows), "*", textcolor);
                        DrawItem.Draw(51, 4 + (5 - emptyRows), "*", textcolor);
                        emptyRows--;
                    }
                }

                Console.WriteLine("\n" + "          *========================================*", textcolor);
            }
            catch (IOException IOError)
            {
                Console.WriteLine(IOError.Message);
            }
            catch (OutOfMemoryException memoryError)
            {
                Console.WriteLine(memoryError.Message);
            }
            catch (Exception another)
            {
                Console.WriteLine(another.Message);
            }
        }

        public static List<string> GetAllScores()
        {
            StreamReader reader = new StreamReader(FILEPATH);

            List<string> allScoresAndNames = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    allScoresAndNames.Add(line);
                    line = reader.ReadLine();
                }
            }

            allScoresAndNames.Sort();
            allScoresAndNames.Reverse();

            return allScoresAndNames;
        }

        public static List<string> GetHighScores()
        {
            List<string> allScoresAndNames = GetAllScores();

            if (allScoresAndNames.Count > 5)
            {
                allScoresAndNames.RemoveRange(5, allScoresAndNames.Count - 5);
            }

            List<string> fiveTopPlayers = allScoresAndNames;

            return fiveTopPlayers;
        }

        public static void WriteScores()
        {
            string scores = currentScores.ToString("0000");
            string recordScores = scores + "|" + playerNameGameOver;

            StreamWriter writer = new StreamWriter(FILEPATH, true);
            using (writer)
            {
                writer.WriteLine(recordScores);
            }
        }
    }
}