using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schelet_backend
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    enum Resources
    {
        Wheat,
        Sheep,
        Clay,
        Stone,
        Wood,
        Desert,
        Ocean
    }

    enum Settlements
    {
        Village,
        City
    }

    class Node
    {
        public int id { get; set; }
        public List<Node> nodeNeighbors { get; set; }
        public List<Node> hasRoadWith { get; set; }
        public List<Hex> hexNeighbors { get; set; }

        private bool hasPort;
        /*public bool HasPort
        {
            get
            {
                return hasPort;
            }
            private set
            {
                hasPort = value;
            }
        }*/
        public Resources portTradedResource { get; set; }

        public bool hasSettlement { get; set; }
        public Player playerSettled;
        public Settlements settlementType { get; set; }

        

        public Node(int id)
        {
            this.id = id;
            //completat cu restul atributelor default (gen hassettlement false etc)

        }
    }

    class Hex
    {
        public int id { get; set; }
        public Resources resource { get; set; }
        public int number { get; set; }
        public bool hasRobber { get; set; }
        public List<Node> nodeNeighbors { get; set; }


        public Hex(int id, Resources resource, int number)
        {
            this.id = id;
            this.resource = resource;
            this.number = number;
            this.hasRobber = false;
        }

        public Hex(int id)
        {
            this.id = id;
            this.resource = Resources.Ocean;
            this.number = -1;
            this.hasRobber = false;
        }
    }

    class Map
    {
        public List<Node> nodes { get; set; }
        public List<Hex> hexes { get; set; }

        public Map()
        {
            initHexes();
            initNodes();
            connect();
            makePorts();
        }

        //create all new nodes, add to list
        private void initNodes()
        {
            //loop 1..54 generare cu constructorul doar cu id, restul se intampla in connect
        }

        //create all new hexes, add to list
        private void initHexes()
        {
            //for loop 1..19 hexurile cu resurse pe ele
            //genererare RELEVANTA, CU CAP a resursa, numar -> apelare constructor cu toate

            //for loop 1..18 hexurile cu ocean de pe exterior -> folosire constructor doar cu id

            //

        }

        //populate lists of neighbors in each
        private void connect()
        {
            //parcurgere lista de hexuri
            //hex 1 . setlistavecininoduri(new list {1, 2, 3, 9, 10, 11 } etc

            //parcurgere lista de noduri
            //nod1 .setlistavecininoduri (new list {..} etc
            //la fel setlistavecinihexuri
            //necesar creeare setters la listele astea de vecini
        }

        private void makePorts()
        {
            //generare porturi (hardcodate), randomizare doar ce trade au
        }

    }

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

    class Road
    {
        public Node node1 { get; set; }
        public Node node2 { get; set; }
        public Player owner { get; set; }
    }

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




    }
}
