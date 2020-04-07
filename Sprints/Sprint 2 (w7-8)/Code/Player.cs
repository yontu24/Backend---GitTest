using System;
using System.Collections.Generic;
using System.Text;

namespace Catan
{
    class Player
    {
        private string name;
        private int id;
        private int points;

        private List<Road> allRoads = new List<Road>();
        private List<Node> settledNodes = new List<Node>();

        private int wheatQty;
        private int sheepQty;
        private int clayQty;
        private int stoneQty;
        private int woodQty;

        private int villagesLeft;
        private int citiesLeft;
        private int roadsLeft;

        private int knightCardsLeft;
        private int victoryPointCardsLeft;
        private int roadBuildingCardsLeft; 
        private int yearOfPlentyCardsLeft;
        private int monopolyCardsLeft;

        private int soldierCardsUsed;
        private bool hasLongestRoad;

        // CONSTRUCTOR 

        public Player() {}

        public Player(string name)
        {
            this.name = name;
            this.points = 0;

            this.wheatQty = 0;
            this.sheepQty = 0;
            this.clayQty = 0;
            this.stoneQty = 0;
            this.woodQty = 0;

            this.villagesLeft = 5;
            this.citiesLeft = 5;
            this.roadsLeft = 15;

            this.knightCardsLeft = 0;
            this.victoryPointCardsLeft = 0;
            this.roadBuildingCardsLeft = 0;
            this.yearOfPlentyCardsLeft = 0;
            this.monopolyCardsLeft = 0;

            this.soldierCardsUsed = 0;
            this.hasLongestRoad = false;
        }

        public override string ToString()
        {
            return "Player name: " + name; 
        }

        // METHODS
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

        // GETTERS AND SETTERS
        public String Name { get{return this.name;} set{this.name = value;} }
        public int Id { get{return this.id;} set{this.id = value;} }
        public int Points { get{return this.points;} set{this.points = value;} }

        public List<Road> AllRoads { get{return this.allRoads;} set { this.allRoads = value; } }
        public List<Node> SettledNodes { get{return this.settledNodes;} set { this.settledNodes = value; } }

        public int WheatQty { get{return this.wheatQty;} set{this.wheatQty = value;} }
        public int SheepQty { get{return this.sheepQty;} set{this.sheepQty = value;} }
        public int ClayQty { get{return this.clayQty; } set{this.clayQty = value;} }
        public int StoneQty { get{return this.stoneQty;} set{this.stoneQty = value;} }
        public int WoodQty { get{return this.woodQty;} set{this.woodQty = value;}}

        public int VillagesLeft { get{return this.villagesLeft;} set{this.villagesLeft = value;} }
        public int CitiesLeft { get{return this.citiesLeft;} set{this.citiesLeft = value;} }
        public int RoadsLeft { get{return this.roadsLeft;} set{this.roadsLeft = value;} }

        public int KnightCardsLeft{ get{return this.knightCardsLeft;} set{this.knightCardsLeft = value;} }
        public int VictoryPointCardsLeft { get{return this.victoryPointCardsLeft;} set{this.victoryPointCardsLeft = value;} }
        public int RoadBuildingCardsLeft { get{ return this.roadBuildingCardsLeft;} set{this.roadBuildingCardsLeft = value;} }
        public int YearOfPlentyCardsLeft { get{return this.yearOfPlentyCardsLeft;} set{this.yearOfPlentyCardsLeft = value;} }
        public int MonopolyCardsLeft { get{return this.monopolyCardsLeft;} set{this.monopolyCardsLeft = value;} }

        public int SoldierCardsUsed { get{return this.soldierCardsUsed;} set{ this.soldierCardsUsed = value;} }
        public bool HasLongestRoad { get{return this.hasLongestRoad;} set{ this.hasLongestRoad = value;} }
    }
}
