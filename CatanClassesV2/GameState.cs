using System;
using System.Collections.Generic;
using System.Text;

namespace Catan
{
    class GameState
    {
        private Map map = new Map();
        private int knightCardsLeft;
        private int victoryPointCardsLeft;
        private int roadBuildingCardsLeft;
        private int yearOfPlentyCardsLeft;
        private int monopolyCardsLeft;
        private List<Player> players = new List<Player>();
        private Player longestRoadPlayer = new Player();

        // CONSTRUCTOR
        public GameState(Map map, List<Player> players) { this.map = map; this.players = players; } //initializare nr carti ramase cu cate carti sunt in pachet initia

        // GETTERS AND SETTERS
        public Map Map { get{return this.map;} }
        public int KnightCardsLeft { get{return this.knightCardsLeft;} set{this.knightCardsLeft=value;} }
        public int VictoryPointsCardsLeft { get{return this.victoryPointCardsLeft;} set{this.victoryPointCardsLeft=value;} }
        public int RoadBuildingCardsLeft { get{return this.roadBuildingCardsLeft;} set{this.roadBuildingCardsLeft=value;} }
        public int YearOfPlentyCardsLeft { get{return this.yearOfPlentyCardsLeft;} set{this.yearOfPlentyCardsLeft = value;} }
        public int MonopolyCardsLefts { get{return this.monopolyCardsLeft;} set{this.monopolyCardsLeft=value;} }
        public List<Player> Players { get {return this.players;} set{this.players = value;} }
        public Player LongestRoadPlayer { get{return this.longestRoadPlayer;} set{this.longestRoadPlayer = value;} }
    }
}
