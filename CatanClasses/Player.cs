using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Player
    {
        public string name { get; set; }
        public int id { get; set; }
        private int points;

        public int wheat { get; set; }
        public int sheep;
        public int clay;
        public int stone;
        public int wood;

        public List<Node> settledNodes;

        public int villagesLeft;
        public int citiesLeft;
        public int roadsLeft;

        public int soldierCardsUsed;
        public bool hasLongestRoad;


        public int knightCardsLeft { get; set; }
        public int victoryPointCardsLeft { get; set; }
        public int roadBuildingCardsLeft { get; set; }
        public int yearOfPlentyCardsLeft { get; set; }
        public int monopolyCardsLeft { get; set; }


        public void useKnightCard()
        {
            //
        }

        public void useRoadBuildingCard()
        {
            //
        }

        public void useYearOfPlentyCard()
        {
            //
        }

        public void useMonopolyCard()
        {
            //
        }

    }
}
