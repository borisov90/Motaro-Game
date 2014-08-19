namespace Game
{
    using System;
    using System.Drawing;

    class Terrain
    {
        public static void Initialize()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            string ground = new String('\u2588', 50);
            char grass = '|';



            for (int col = 0; col < WindowsSettings.GAME_AREA_WIDTH; col += 2)
            {
                DrawItem.Draw(col, WindowsSettings.WIN_HEIGHT - 5, grass, ConsoleColor.DarkGreen);
            }
            
            DrawItem.Draw(0, WindowsSettings.WIN_HEIGHT - 4, ground, ConsoleColor.DarkGreen);
            DrawItem.Draw(0, WindowsSettings.WIN_HEIGHT - 3, ground, ConsoleColor.DarkGreen);
            DrawItem.Draw(0, WindowsSettings.WIN_HEIGHT - 2, ground, ConsoleColor.DarkGreen);
            DrawItem.Draw(0, WindowsSettings.WIN_HEIGHT - 1, ground, ConsoleColor.DarkGreen);

        }                                                    
    } 
                                          
}                                                             
