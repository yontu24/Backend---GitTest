using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class GameState
    {
        public Map map { get; set; }
        public List<Player> players { get; set; }

        public int knightCardsLeft { get; set; }
        public int victoryPointCardsLeft { get; set; }
        public int roadBuildingCardsLeft { get; set; }
        public int yearOfPlentyCardsLeft { get; set; }
        public int monopolyCardsLeft { get; set; }

        public Player longestRoadPlayer;

        public GameState(Map map, List<Player> players)
        {
            this.map = map;
            this.players = players;

            //initializare nr carti ramase cu cate carti sunt in pachet initial
        }
    }
}
