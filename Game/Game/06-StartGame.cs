namespace Game
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class StartGame
    {
        public static string secondsToGameOver;
        public static Stopwatch stopWatch1 = new Stopwatch();
        const int INTERVAL = 100;

        public static void Initialize()
        {
            stopWatch1.Reset();
            stopWatch1.Start();

            Sound.StopMenuMusic();
            Sound.PlayIngameMusic();

            TimeSpan timeSpan1 = new TimeSpan();

            TimeSpan diagnoze = DateTime.Now.AddSeconds(59) - DateTime.Now; // change AddSeconds(int) with the game time
            timeSpan1 = diagnoze.Subtract(stopWatch1.Elapsed);
            secondsToGameOver = String.Format("{0}", timeSpan1.Seconds.ToString("00"));

            while (Player.playerLife > 0 || secondsToGameOver != "00")
            {
                Terrain.Initialize();

                Bombs.GenerateBomb();
                Bombs.ShowBombs();
                
                Bandit.ChangePosition();
                Bandit.ShowPosition();

                Rackets.UpdateShot();
                CollisionDetection.CollisionRacketsAndBandits();
                Rackets.DrawRackets();

                RightInfoArea.Initialize();

                Player.ShowPosition();
                Player.ChangePosition();

                CollisionDetection.CollisionPlayerAndBombs();

                // CODE FOR TIME starts //
                timeSpan1 = diagnoze.Subtract(stopWatch1.Elapsed);
                secondsToGameOver = String.Format("{0}", timeSpan1.Seconds.ToString("00"));

                Thread.Sleep(INTERVAL);

                if (Player.playerLife <= 0 || secondsToGameOver == "00")
                {
                    stopWatch1.Stop();
                    GameOver.Initialize();
                    return;
                }
            }
        }
    }
}