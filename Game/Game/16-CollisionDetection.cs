using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //TO DO Remove Bandits after being hit by Rackets
    class CollisionDetection
    {
        public static void CollisionRacketsAndBandits()
        {
            for (int i = 0; i < Rackets.shots.Count; i++)
            {
                if (Bandit.banditPositionX == Rackets.shots[i][0] && Bandit.banditPositionY - 1 == Rackets.shots[i][1]
                    || Bandit.banditPositionX + 1 == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1]
                    || Bandit.banditPositionX - 1 == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1]
                    || Bandit.banditPositionX == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1] 
                    || Bandit.banditPositionX == Rackets.shots[i][0] && Bandit.banditPositionY + 1 == Rackets.shots[i][1])
                {
                    Scores.currentScores += 30;
                    Rackets.shots.RemoveAt(i);

                    // removes the airplane
                    Bandit.GenerateNewPosition();
                }


                else if (Bandit.banditPositionX + 2 == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1] 
                    || Bandit.banditPositionX + 3 == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1]
                    || Bandit.banditPositionX + 4 == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1]
                    || Bandit.banditPositionX + 5 == Rackets.shots[i][0] && Bandit.banditPositionY == Rackets.shots[i][1])
                {
                    Scores.currentScores += 20;
                    Rackets.shots.RemoveAt(i);

                    // removes the airplane
                    Bandit.GenerateNewPosition();
                }
            }
        }
        public static void CollisionPlayerAndBombs()
        {
            for (int i = 0; i < Bombs.bombsList.Count; i++)
            {
                if (Player.playerPositionX == Bombs.bombsList[i][0] && Player.playerPositionY - 1 == Bombs.bombsList[i][1] ||                      Player.playerPositionX + 1 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] ||                      Player.playerPositionX == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] ||
                    Player.playerPositionX == Bombs.bombsList[i][0] && Player.playerPositionY + 1 == Bombs.bombsList[i][1] ||                      Player.playerPositionX + 2 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] ||                      Player.playerPositionX + 3 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] ||                      Player.playerPositionX + 7 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] ||                      Player.playerPositionX + 8 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] ||                      Player.playerPositionX + 9 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1])
                {
                    Player.playerLife -= 40;
                    Console.Beep();
                    Bombs.bombsList.RemoveAt(i);
                    Bombs.GenerateBomb();
                    RightInfoArea.Initialize();
                }
                else if (Player.playerPositionX + 4 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1]                     || Player.playerPositionX + 5 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1] 
                     || Player.playerPositionX + 6 == Bombs.bombsList[i][0] && Player.playerPositionY == Bombs.bombsList[i][1])
                {
                    Player.playerLife -= 50;
                    Console.Beep();
                    Bombs.bombsList.RemoveAt(i);
                    Bombs.GenerateBomb();
                    RightInfoArea.Initialize();
                }
            }
        }
    }
}
