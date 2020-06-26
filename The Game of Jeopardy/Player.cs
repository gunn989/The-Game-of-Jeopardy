using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game_of_Jeopardy
{
    class Player
    {
        // Sets up player object
        public string playerName { get; set; }
        public int points { get; set; }

        // Player constructor
        public Player (string plyrName, int plyrPoints)
        {
            playerName = plyrName;
            points = plyrPoints;
        }

        public string getName()
        {
            return playerName;
        }

        public int getPoints()
        {
            return points;
        }
    }
}
