using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class GameState
    {
        private Map map = new Map();

        public Map Map
        {
            get { return this.map; }

        }
        private List<Player> players = new List<Player>();
        public List<Player> Players
        {
            get
            {
                return this.players;
            }
        }

        private int knightCardsLeft;

        public int KnightCardsLeft
        {
            get
            {
                return this.knightCardsLeft;
            }
            set
            {
                this.knightCardsLeft = value;
            }
        }

        private int victoryPointCardsLeft;

        public int VictoryPointsCardsLeft
        {
            get
            {
                return this.victoryPointCardsLeft;
            }
            set
            {
                this.victoryPointCardsLeft = value;
            }
        }

        private int roadBuildingCardsLeft;

        public int RoadBuildingCardsLeft
        {
            get
            {
                return this.roadBuildingCardsLeft;
            }
            set
            {
                this.roadBuildingCardsLeft = value;
            }
        }
        private int yearOfPlentyCardsLeft;

        public int YearOfPlentyCardsLeft
        {
            get
            {
                return this.yearOfPlentyCardsLeft;
            }
            set
            {
                this.yearOfPlentyCardsLeft = value;
            }
        }
        private int monopolyCardsLeft;

        public int MonopolyCardsLeft
        {
            get
            {
                return this.monopolyCardsLeft;
            }
            set
            {
                this.monopolyCardsLeft = value;
            }
        }

        private Player longestRoadPlayer = new Player();
        
        public Player LongestRoadPlayer {

            get
            {
                return this.longestRoadPlayer;
            }

        }

        public GameState(Map map, List<Player> players)
        {
            this.map = map;
            this.players = players;

            //initializare nr carti ramase cu cate carti sunt in pachet initial
        }
    }
}
