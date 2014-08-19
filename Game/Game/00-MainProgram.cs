namespace Game
{
    using System;

    public class GAME
    {
        public static void Main()
        {
            // WINDOW Settings
            WindowsSettings.Initialize();

            // INITIAL Start Menu
            StartMenu.Initialize();
            
            // INITIAL THE GAME
            StartGame.Initialize();
        }
    }
}