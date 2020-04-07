using System;
using System.Collections.Generic;
using System.Text;

namespace Catan
{
    class GameState
    {
        private Map map;
        private List<Player> players = new List<Player>();

        private int knightCardsLeft;
        private int victoryPointCardsLeft;
        private int roadBuildingCardsLeft;
        private int yearOfPlentyCardsLeft;
        private int monopolyCardsLeft;

        //private int noOfPlayers;

        // CONSTRUCTOR

        public GameState() {}

        public GameState(List<Player> players)
        {
            if (players.Count > 4 || players.Count < 3)
            {
                throw new System.ArgumentException("PLAYER NUMBER MUST BE 3 OR 4", "players.Count");
            }

            map = new Map();
            this.players = players;
            this.knightCardsLeft = 14;
            this.victoryPointCardsLeft = 5;
            this.roadBuildingCardsLeft = 2;
            this.yearOfPlentyCardsLeft = 2;
            this.monopolyCardsLeft = 2;
            Console.WriteLine("am ajuns aici");


             players = Shuffler.Shuffle(players);

            Queue<Player> playerOrder = new Queue<Player>();

            foreach (Player player in players)
            {
                playerOrder.Enqueue(player);
            }

           

            while (true)
            {
                foreach (Player player in playerOrder)
                {
                    Tour tour = new Tour(player, players);
                    
                }

                break;
            }

        }


        









        // GETTERS AND SETTERS
        public Map Map { get{return this.map;} }
        public int KnightCardsLeft { get{return this.knightCardsLeft;} set{this.knightCardsLeft=value;} }
        public int VictoryPointsCardsLeft { get{return this.victoryPointCardsLeft;} set{this.victoryPointCardsLeft=value;} }
        public int RoadBuildingCardsLeft { get{return this.roadBuildingCardsLeft;} set{this.roadBuildingCardsLeft=value;} }
        public int YearOfPlentyCardsLeft { get{return this.yearOfPlentyCardsLeft;} set{this.yearOfPlentyCardsLeft = value;} }
        public int MonopolyCardsLefts { get{return this.monopolyCardsLeft;} set{this.monopolyCardsLeft=value;} }
        public List<Player> Players { get {return this.players;} set{this.players = value;} }
        //public int NoOfPlayers {get {return this.noOfPlayers;}  set {this.noOfPlayers = value;} }
    }
}
