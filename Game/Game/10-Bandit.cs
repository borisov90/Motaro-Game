namespace Game
{
    using System;

    class Bandit
    {

        public static readonly char[] BANDIT_SYMBOL = new char[] {
            ' ', ' ', '/', ' ',                    // row 1
            '\u25C4', '=', '=', '\u255e',     // row 2
            ' ', ' ', '\\', ' '                  // row 3
        };

        public const int BANDIT_HEIGHT = 3;
        public const int BANDIT_WIDTH = 3;

        public const int ADD_SECONDS = 2; // slows down the airplane movement when higher

        public static Random randomGenerator = new Random();

        public static int banditPositionX = WindowsSettings.GAME_AREA_WIDTH;
        public static int banditPositionY = randomGenerator.Next(5, 25);
        public static int startBanditPositionY = banditPositionY;

        public static readonly DateTime initialTimeGame = DateTime.Now; // sets initial time for launching the game

        public static void GenerateNewPosition()
        {
            banditPositionX = WindowsSettings.GAME_AREA_WIDTH;
            banditPositionY = randomGenerator.Next(5, 25);
            startBanditPositionY = banditPositionY;
        }

        public static void ShowPosition()
        {
            int charNumber = 0;
            int row = 0;

            if (banditPositionX == WindowsSettings.GAME_AREA_WIDTH)
            {
                // the airplane is still outside the visible area
                // sets initial time for launching the airplane
                DateTime initialTimeAirplane = DateTime.Now;
            }
            else if (banditPositionX == WindowsSettings.GAME_AREA_WIDTH - 1)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    if (charNumber == 0)
                    {
                        DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                    }

                    if (charNumber == 3)
                    {
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }

            }
            else if (banditPositionX == WindowsSettings.GAME_AREA_WIDTH - 2)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    if (charNumber == 0 || charNumber == 1)
                    {
                        DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                    }

                    if (charNumber == 3)
                    {
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }
            }
            else if (banditPositionX == WindowsSettings.GAME_AREA_WIDTH - 3)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    if (charNumber != 3)
                    {
                        DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                    }
                    if (charNumber == 3)
                    {
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }
            }
            else if (banditPositionX > 0)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                    if (charNumber == 3)
                    {
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }
            }
            else if (banditPositionX == -1)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    if (charNumber != 0)
                    {
                        DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                    }
                    if (charNumber == 3)
                    {
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }
            }
            else if (banditPositionX == -2)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    if (charNumber != 0 && charNumber != 1)
                    {
                        DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                    }
                    if (charNumber == 3)
                    {
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }
            }
            else if (banditPositionX == -3)
            {
                foreach (char banditSymbol in BANDIT_SYMBOL)
                {
                    if (charNumber == 3)
                    {
                        DrawItem.Draw(banditPositionX + charNumber, banditPositionY + row, banditSymbol);
                        row++;
                        charNumber = 0;
                    }
                    else
                    {
                        charNumber++;
                    }
                }
            }
        }

        // each two seconds after the initial time for launching the game the airplane changes its position by one space
        public static void ChangePosition()
        {
            DateTime currentTime = DateTime.Now;
            int addSeconds = ADD_SECONDS;

            if (currentTime >= initialTimeGame.AddSeconds(addSeconds))
            {
                if (banditPositionX <= -4)
                {
                    GenerateNewPosition();
                }
                else
                {
                    banditPositionX--;
                }
            }

            addSeconds += ADD_SECONDS;
        }
    }
}
