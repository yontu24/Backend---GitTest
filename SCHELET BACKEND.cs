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
            Map map = new Map();
        }
    }

    enum Resources
    {
        Wheat = 4,
        Sheep = 4,
        Wood = 4,
        Clay = 3,
        Stone = 3,
        Desert = 1,
        Ocean,
        None
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
        //public List<Hex> hexNeighbors { get; set; } 


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
            for (int i = 1; i <= 54; i++)
            {
                Node item = new Node(i);
                nodes.Add(item);
            }
        }

        //create all new hexes, add to list
        private void initHexes()
        {
            //for loop 1..19 hexurile cu resurse pe ele
            //genererare RELEVANTA, CU CAP a resursa, numar -> apelare constructor cu toate

            //for loop 1..18 hexurile cu ocean de pe exterior -> folosire constructor doar cu id

            int clay = 0, wood = 0, wheat = 0, sheep = 0, stone = 0, desert = 0;
            int[] tokens = new int[13];

            tokens[2] = 1;
            tokens[12] = 1;

            for (int i = 2; i <= 12; i++)
            {
                tokens[i] = 2;
            }

            Random rand = new Random();

            int ind = rand.Next(2, 13);
            int randomToken = tokens[ind];
            tokens[ind]--;

            //Hex hexItem = new Hex(0, Resources.None, 0);

            for (int i = 1; i <= 19; i++)
            {

                //var values = Enum.GetValues(typeof(Resources));
                List<String> resources = new List<String>() { "Wheat", "Sheep", "Wood", "Clay", "Desert" };

                String randomResource = resources[rand.Next(0, resources.Count)];

                while (randomToken == 0)
                {
                    ind = rand.Next(2, 13);
                    randomToken = tokens[ind];

                }
                tokens[ind]--;

                bool generated = false;

                while (!generated)
                {
                    switch (randomResource)
                    {
                        case "Clay":
                            if (++clay < (int)Resources.Clay)
                            {
                                Hex hexItem = new Hex(i, Resources.Clay, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Wheat":
                            if (++wheat < (int)Resources.Wheat)
                            {
                                Hex hexItem = new Hex(i, Resources.Wheat, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;


                        case "Wood":
                            if (++wood < (int)Resources.Wood)
                            {
                                Hex hexItem = new Hex(i, Resources.Wood, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Stone":
                            if (++stone < (int)Resources.Stone)
                            {
                                Hex hexItem = new Hex(i, Resources.Stone, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Sheep":
                            if (++sheep < (int)Resources.Sheep)
                            {
                                Hex hexItem = new Hex(i, Resources.Sheep, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Desert":
                            if (++desert < (int)Resources.Desert)
                            {
                                Hex hexItem = new Hex(i, Resources.Desert, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        default:
                            Console.WriteLine("eraore");
                            break;
                    }
                }

            }


            //oceane exterioare
            for (int i = 1; i <= 18; i++)
            {
                hexes.Add(new Hex(0 - i));
            }

            foreach (Hex hex in hexes)
            {
                Console.WriteLine(hex);
            }

            foreach (Hex item in hexes)
            {
                if (item.number == 6 || item.number == 8)
                {

                }
            }

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
