/*
 * missile = raketa
 */

namespace Game
{
    using System;
    using System.Collections.Generic;

    // The List has as index of all the shots
    // The List in the List contains two numbers - shot's position X with index 0 and shot's position Y with index 1

    public class Rackets
    {
        public const char RACKET_SYMBOL = '\u2551';
        public static List<List<int>> shots = new List<List<int>>();

        public static int indexOfClosestRacket;
        public static int positionYOfClosestRacket;

        public static void UpdateShot()
        {
            int currentIndexOfClosestRacket = int.MinValue;
            int currentPositionYOfClosestRacket = int.MinValue;
            int indexToDelete = int.MinValue;

            for (int index = 0; index < shots.Count; index++)
            {
                shots[index][1]--; // updates the position Y of the shot

                if (shots[index][1] < 0)
                {
                    indexToDelete = index;
                }

                if (shots[index][1] > currentPositionYOfClosestRacket)
                {
                    currentPositionYOfClosestRacket = shots[index][1];
                    currentIndexOfClosestRacket = index;
                }
            }
 	
            if (indexToDelete >= 0)
            {
                shots.RemoveAt(indexToDelete); // removes the shot that reached the top
            } 

            positionYOfClosestRacket = currentPositionYOfClosestRacket;
            indexOfClosestRacket = currentIndexOfClosestRacket;
        }

        public static void DrawRackets()
        {
            foreach (List<int> shot in shots)
            {
                DrawItem.Draw(shot[0], shot[1], RACKET_SYMBOL);
            }
        }

        public static List<List<int>> AddShots(int playerPosition, int maxHeight)
        {
            shots.Add(new List<int>() { playerPosition + (Player.PLAYER_WIDTH / 2), maxHeight - Player.PLAYER_HEIGHT });
            return shots;
        }
    }
}
