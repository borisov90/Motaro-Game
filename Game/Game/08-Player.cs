namespace Game
{
    using System;
    using System.Threading;
    class Player
    {
        public static readonly string[] PLAYER_SYMBOL = new string[] {
            "   [ ]   ",
            "    =    ",
            " _**=**_ ",
            "|## = ##|",
            "|@@=-=@@|"
        };   

        public const int PLAYER_HEIGHT = 5;
        public const int PLAYER_WIDTH = 9;

        public static int playerPositionX = WindowsSettings.GAME_AREA_WIDTH / 2 - 3;
        public static int playerPositionY = WindowsSettings.GAME_AREA_HEIGHT - PLAYER_HEIGHT - 4;

        private const int SPEED = 100;
        private const int LIFE = 200;

        public static int playerLife = LIFE;
        public static int playerSpeed = SPEED;

        public static void ChangePosition()
        {
                //TODO: Забавяме движението на ляво-дясно
                
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (playerPositionX >= 1)
                    {
                        playerPositionX--;
                    }
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (playerPositionX < WindowsSettings.GAME_AREA_WIDTH - PLAYER_WIDTH)
                    {
                        playerPositionX++;
                    }
                }
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    // if the last racket is at a certain position y add new racket
                    if (Rackets.positionYOfClosestRacket < Player.playerPositionY - 5) 
                    {
                        Rackets.AddShots(playerPositionX, WindowsSettings.GAME_AREA_HEIGHT);
                        break;
                    }
                }
                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.Clear();
                    Environment.Exit(0);
                }
                if (pressedKey.Key == ConsoleKey.P)
                {
                    Sound.StopIngameMusic();
                    DrawItem.Draw(WindowsSettings.GAME_AREA_WIDTH / 2 - 10, WindowsSettings.GAME_AREA_HEIGHT / 2 - 5, "Press any key to resume...", ConsoleColor.Yellow);                  
                    Console.ReadKey(true);

                    if (Sound.isPlayingMusic == true)
                    {
                        Sound.PlayIngameMusic(); 
                    }                               
                }
                if (pressedKey.Key == ConsoleKey.M)
                {
                    Sound.PauseIngameMusic();
                }
                if (pressedKey.Key == ConsoleKey.S)
                {
                    Sound.PlayIngameMusic();
                }
            }
        }

        public static void ShowPosition()
        {
            int row = 0;
            foreach (string playerSymbolRow in PLAYER_SYMBOL)
            {
                DrawItem.Draw(playerPositionX, playerPositionY + row, playerSymbolRow);
                row++;
            }
        }
    }
}
