namespace Game
{
    using System;
    class RightInfoArea
    {
        const string SYMBOL = "|";

        public static void Initialize()
        {
            for (int row = 0; row < WindowsSettings.INFO_AREA_HEIGHT; row++)
            {
                DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH, row, SYMBOL);
            }

            DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 4, "Press M to Mute!");
            DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 6, "Press P for Pause!");
            DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 8, "Press ESC to quit!");
            DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 44, "Time: " + StartGame.secondsToGameOver);
            DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 46, "Scores: " + Scores.currentScores);
            // DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 26, "Level: 1");                    

            DrawItem.Draw(WindowsSettings.INFO_AREA_WIDTH + 2, 48, "Life Points: " + Player.playerLife);
        }
    }
}
