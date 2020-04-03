using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Player
    {
        private string name;
        private int id;
        private int points;

        private int wheat;
        private int sheep;
        private int clay;
        private int stone;
        private int wood;

        private List<Road> allRoads = new List<Road>();
        private List<Node> settledNodes = new List<Node>();

        private int villagesLeft;
        private int citiesLeft;
        private int roadsLeft;

        private int soldierCardsUsed;
        private bool hasLongestRoad;

        private int knightCardsLeft;
        private int victoryPointCardsLeft;
        private int roadBuildingCardsLeft; 
        private int yearOfPlentyCardsLeft;
        private int monopolyCardsLeft; 

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
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public int Wheat
        {
            get
            {
                return this.wheat;
            }
            set
            {
                this.wheat = value;
            }
        }

        public int Sheep
        {
            get
            {
                return this.sheep;
            }
            set
            {
                this.sheep = value;
            }
        }

        public int Clay
        {
            get
            {
                return this.clay;
            }
            set
            {
                this.clay = value;
            }
        }

        public int Stone
        {
            get
            {
                return this.stone;
            }
            set
            {
                this.stone = value;
            }
        }

        public int Wood
        {
            get
            {
                return this.wood;
            }
            set
            {
                this.wood = value;
            }
        }
        public List<Road> AllRoads
        {
            get
            {
                return this.allRoads;

            }
        }
        public List<Node> SettledNodes
        {
            get
            {
                return this.settledNodes;

            }
        }

        public int VillagesLeft
        {
            get
            {
                return this.villagesLeft;
            }
            set
            {
                this.villagesLeft = value;
            }
        }

        public int CitiesLeft
        {
            get
            {
                return this.citiesLeft;
            }
            set
            {
                this.citiesLeft = value;
            }
        }

        public int RoadsLeft
        {
            get
            {
                return this.roadsLeft;
            }
            set
            {
                this.roadsLeft = value;
            }
        }

        public int SoldierCardsUsed
        {
            get
            {
                return this.soldierCardsUsed;
            }
            set
            {
                this.soldierCardsUsed = value;
            }
        }

        public bool HasLongestRoad
        {
            get
            {
                return this.hasLongestRoad;
            }
            set
            {
                this.hasLongestRoad = value;
            }
        }

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

        public int VictoryPointCardsLeft
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

    }
}
