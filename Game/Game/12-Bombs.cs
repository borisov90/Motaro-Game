namespace Game
{
    using System;
    using System.Collections.Generic;

    class Bombs
    {
        public const string BOMB_SYMBOL = "@";
        public const int BOMB_HEIGHT = 1;
        public const int BOMB_WIDTH = 1;
        public const int BOMB_SPEED = 2; // sec

        public static int bombPositionX;
        public static int bombPositionY;

        public static List<int[]> bombsList = new List<int[]>();
        public static sbyte bombNumber = 0;

        public static void GenerateBomb()
        {
            bombPositionY = Bandit.banditPositionY + Bandit.BANDIT_HEIGHT;

            if (Bandit.banditPositionX >= (WindowsSettings.GAME_AREA_WIDTH / 2) && bombNumber == 0)
            {
                bombPositionX = new Random().Next(WindowsSettings.GAME_AREA_WIDTH / 2, WindowsSettings.GAME_AREA_WIDTH);
                bombNumber = 1;
            }
            else if (Bandit.banditPositionX < (WindowsSettings.GAME_AREA_WIDTH / 2)
                    && Bandit.banditPositionX >= 0
                    && bombNumber == 1)
            {
                bombPositionX = new Random().Next(0, WindowsSettings.GAME_AREA_WIDTH / 2);
                bombNumber = 0;
            }

            if (bombPositionX == Bandit.banditPositionX + (Bandit.BANDIT_WIDTH / 2))
            {
                DrawItem.Draw(bombPositionX, bombPositionY, BOMB_SYMBOL);
                bombsList.Add(new int[] { bombPositionX, bombPositionY });
            }
        }

        public static void ShowBombs()
        {
            int addSeconds = BOMB_SPEED;

            bool anyBombs = false;
            for (int index = 0; index < bombsList.Count; index++)
            {
                // loops through x and y
                for (int i = 0; i < 2; i++)
                {
                    if (bombsList[index][i] != int.MinValue)
                    {
                        anyBombs = true;
                        break;
                    }
                }
            }

            if (anyBombs)
            {
                for (int index = 0; index < bombsList.Count; index++)
                {
                    if (bombsList[index] != new int[] { int.MinValue, int.MinValue })
                    {
                        // bombsList[index][1] = bombPositionY
                        if (bombsList[index][1] < WindowsSettings.GAME_AREA_HEIGHT - 5)
                        {
                            bombsList[index][1] += 1;
                        }
                        else if (bombsList[index][1] == WindowsSettings.GAME_AREA_HEIGHT - 5)
                        {
                            bombsList[index][0] = int.MinValue;
                            bombsList[index][1] = int.MinValue;
                        }
                        }
                    }

                for (int index = 0; index < bombsList.Count; index++)
                {
                    if (bombsList[index][0] != int.MinValue && bombsList[index][1] != int.MinValue)
                    {
                        DrawItem.Draw(bombsList[index][0], bombsList[index][1], BOMB_SYMBOL);
                    }
                }
            }

            addSeconds += BOMB_SPEED;
        }
    }
}
